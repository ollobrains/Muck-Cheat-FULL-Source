using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MuckCheat
{
    /// <summary>
    /// Class responsible for displaying the MuckCheat window and its functionalities.
    /// </summary>
    internal class Cheat : MonoBehaviour
    {
        // Rect to specify the position and size of the window
        Rect windowRect = new Rect(20, 20, 120, 100);
        // Instance of the GlobalVariables class
        GlobalVariables gv = GlobalVariables.Instance;

        /// <summary>
        /// GUI method to draw the MuckCheat window.
        /// </summary>
        public void OnGUI()
        {
            // Draw the window with id 0, with the specified rect, the Window method and a title "MuckCheat"
            windowRect = GUILayout.Window(0, windowRect, Window, "MuckCheat");
            // Call the MobESP method if the mobESP toggle is on
            if (gv.mobESP) gv.MobESP();
        }

        /// <summary>
        /// Update method to detect the key press and teleport the player.
        /// </summary>
        void Update()
        {
            // If the key "C" is pressed
            if (Input.GetKeyDown(KeyCode.C))
            {
                // Log "RaycastTeleport key pressed!"
                gv.Log("RaycastTeleport key pressed!");
                // Call the RayCastTeleport method
                gv.RayCastTeleport();
            }
        }

        /// <summary>
        /// Method to draw the contents of the MuckCheat window.
        /// </summary>
        /// <param name="id">The id of the window.</param>
        private void Window(int id)
        {
            // Label to display the title of the cheat
            GUILayout.Label("MuckCheat", gv.Style());
            // Label to display the version of the cheat
            GUILayout.Label("Version: 0.0.1", gv.Style());
            // Label to display the author of the cheat
            GUILayout.Label("Author: ChiChi", gv.Style());
            // Space to add spacing between elements
            GUILayout.Space(10);
            // Label to indicate the start of the cheat menu
            GUILayout.Label("Cheat Menu");
            // Begin horizontal layout to display the toggles in one line
            GUILayout.BeginHorizontal();
            // Toggle to enable or disable mob ESP
            gv.mobESP = GUILayout.Toggle(gv.mobESP, "Toggle mob ESP");
            // Toggle to enable or disable chest ESP
            gv.chestESP = GUILayout.Toggle(gv.chestESP, "Toggle chest ESP (try adding this)");
            // End the horizontal layout
            GUILayout.EndHorizontal();
            // Label to display instructions to teleport
            GUILayout.Label("Press (C) to teleport to where you are looking");
            // Check if the player's status is not null
            if (gv.GetPlayerStatus() != null)
            {
                // Show health slider label
                GUILayout.BeginHorizontal();
                GUILayout.Label("Health Slider");

                // Display the horizontal slider for adjusting player's health
                gv.GetPlayerStatus().hp = GUILayout.HorizontalSlider(gv.GetPlayerStatus().hp, 0, gv.GetPlayerStatus().maxHp);
                GUILayout.EndHorizontal();

                // Show stamina slider label
                GUILayout.BeginHorizontal();
                GUILayout.Label("Stamina Slider");

                // Display the horizontal slider for adjusting player's stamina
                GUILayout.HorizontalSlider(gv.GetPlayerStatus().stamina, 0, gv.GetPlayerStatus().maxStamina);

                // Note: this shows the bar position but does not change the value
                GUILayout.EndHorizontal();
            }

            // Allows the window to be dragged around the screen
            GUI.DragWindow();
        }
    }
}
