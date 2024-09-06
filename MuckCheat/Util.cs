using MuckCheat.ICS2_ChiChi.helpers;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MuckCheat
{
    // This is the Util class which provides various functionalities for the game
    internal class Util
    {
        // GlobalVariables instance
        GlobalVariables gv = GlobalVariables.Instance;

        // RayCastTeleport method is used to teleport the player to a new position based on the raycast hit point
        public void RayCastTeleport()
        {
            // Get the player camera's transform
            Transform transform = PlayerMovement.Instance.playerCam;
            RaycastHit raycast;
            // Cast a ray from the player camera
            if (Physics.Raycast(transform.position, transform.forward, out raycast, 2000f))
            {
                Vector3 point = Vector3.zero;
                // Check if the hit object is on the "Ground" layer
                if (raycast.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    point = Vector3.one;
                }
                // Teleport the player to the raycast hit point
                PlayerMovement.Instance.GetRb().position = raycast.point + point;
            }
            return;
        }

        // MobESP method is used to display information about the mobs using ESP (Extra Sensory Perception)
        public void MobESP()
        {
            // Get all the objects with the HitableMob component
            foreach (HitableMob mob in GameObject.FindObjectsOfType<HitableMob>())
            {
                // Call the ESP method for each mob
                ESP(mob.transform, mob.name, Color.magenta, 250f);
                // Sleep for 0.3 seconds
                SleepFor(0.3f);
            }
        }

        // ChestESP method is not implemented yet
        public void ChestESP()
        {
            throw new NotImplementedException(); // add chest esp here
        }

        // ESP method displays information about the given transform using ESP (Extra Sensory Perception)
        public void ESP(Transform transform, string label, Color color, float drawDistance, bool showName = false, bool showDistance = false, bool showLine = true)
        {
            // Convert the world position of the transform to screen coordinates
            Vector3 vector = Camera.main.WorldToScreenPoint(transform.position);
            // Check if the screen coordinates are within the screen bounds
            bool flag = vector.z > 0f & vector.y < (float)(Screen.width - 2);

            if (flag)
            {
                float z = vector.z;
                // Check if the distance is within the draw distance
                if (z < drawDistance)
                {
                    // Screen position calculation
                    vector.y = (float)Screen.height - (vector.y + 1f);

                    // Display distance if showDistance is set to true
                    if (showDistance)
                    {
                        Render.DrawString(new Vector2(vector.x, vector.y), "\n\nDistance: " + vector.z.ToString(), color, true);
                    }

                    // Display label if showName is set to true
                    if (showName)
                    {
                        Render.DrawString(new Vector2(vector.x, vector.y), label, color, true);
                    }

                    // Display line connecting the target to the center of the screen if showLine is set to true
                    if (showLine)
                    {
                        Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(vector.x, vector.y), Color.red, 1f);
                    }
                }
            }
        }

        // The SleepFor function creates a coroutine that waits for a specified amount of time before returning. 
        // This can be useful for pausing code execution for a specific duration, such as to wait for a UI animation to complete or a sound to play. 
        private static IEnumerator SleepFor(float Time)
        {
            yield return new WaitForSeconds(Time);
            yield break;
        }
    }
}
