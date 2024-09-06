using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MuckCheat
{
    [BepInPlugin("dev.chichi.muckcheat", "MuckCheat", "0.0.1")]
    public class Loader : BaseUnityPlugin
    {
        //Create an instance of the GlobalVariables class
        GlobalVariables gv = GlobalVariables.Instance;
        //Create a log source for the MuckCheat plugin
        BepInEx.Logging.ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("MuckCheat");

        //Called when the plugin is loaded
        public void Awake()
        {
            //Log message indicating MuckCheat has loaded
            gv.Log("MuckCheat loaded!");
        }

        //Called after the Awake method
        public void Start()
        {
            //Log message indicating MuckCheat is creating the cheat object
            gv.Log("MuckCheat creating cheat object!");
            //Create the cheat object
            gv.cheatObject = new GameObject("MuckCheatObject");
            if (gv.cheatObject != null)
            {
                //Log message indicating the cheat object has been created
                gv.Log("MuckCheat cheat object created!");
                //Add the Cheat component to the cheat object
                gv.cheatObject.AddComponent<Cheat>();
                //Ensure the cheat object is not destroyed when a new scene is loaded
                DontDestroyOnLoad(gv.cheatObject);
            }
            else
            {
                //Log message indicating the cheat object failed to create
                gv.Log("MuckCheat cheat object failed to create!");
                //Return from the method
                return;
            }
        }
    }
}
