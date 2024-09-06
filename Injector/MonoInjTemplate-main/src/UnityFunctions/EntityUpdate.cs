using System.Collections;
using UnityEngine;

namespace MonoInjectionTemplate
{
    partial class HackMain : MonoBehaviour
    {
        private IEnumerator EntityUpdate;
        private IEnumerator EntityUpdateFunct(float time)
        {
            yield return new WaitForSeconds(time);
            // Update Entities here //
            
            AssignCamera();

            _mobs = FindObjectsOfType<Mob>();
            
            ///////////////////////////
            EntityUpdate = EntityUpdateFunct(5);
            StartCoroutine(EntityUpdate);
        }
    }
}