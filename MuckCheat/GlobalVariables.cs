using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MuckCheat
{
    internal class GlobalVariables : Util
    {
        // Property to access the singleton instance of this class
        internal static GlobalVariables Instance { get; } = new GlobalVariables();

        // Logger for logging messages
        internal BepInEx.Logging.ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("MuckCheat");

        // Game object variable, might represent some object in the game
        internal GameObject cheatObject;

        // Class storing information about player status
        internal PlayerStatus playerStatus;

        // guiSkin variable to store the GUI skin
        internal GUISkin guiSkin;

        // style variable to store the GUI style
        internal GUIStyle style;

        // Variables to store the status of cheats
        internal bool mobESP = false;
        internal bool chestESP = false;
        private Camera mainCamera;

        // Private constructor to prevent instantiation of this class
        private GlobalVariables() { }

        // Method to retrieve player status and update it if it's not set
        public PlayerStatus GetPlayerStatus()
        {
            if (playerStatus == null)
            {
                playerStatus = PlayerStatus.Instance;
            }
            return playerStatus;
        }

        // Check if the singleton instance of this class is null
        public static bool IsNull() => Instance == null;

        // Method to log a message to the console with a yellow background color
        public void Log(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            logger.LogInfo(message);
            Console.ResetColor();
        }

        // Method to get the main camera and update it if it's not set
        public Camera GetMainCamera()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
            return mainCamera;
        }
        
        public GUIStyle Style()
        {
            if (style != null)
                return style;
            style = new GUIStyle();
            style.normal.textColor = Color.red;
            style.normal.background = Texture2D.whiteTexture;
            return style;
        }
    }
}
