using System;
using UnityEngine;
using BepInEx.Logging;

namespace MuckCheat
{
    // Renamed to "GlobalManager" or "CheatManager" to be more descriptive,
    // but you can keep "GlobalVariables" if you prefer.
    internal class GlobalVariables : Util
    {
        // Singleton instance, making it readonly to prevent runtime changes
        internal static readonly GlobalVariables Instance = new GlobalVariables();

        // BepInEx logger instance
        // Moved to a property style for clarity
        internal ManualLogSource Logger { get; } = BepInEx.Logging.Logger.CreateLogSource("MuckCheat");

        // The cheatObject might represent your custom in-game object
        internal GameObject CheatObject { get; set; }

        // PlayerStatus variable
        // Encouraging short inline docs for clarity.
        internal PlayerStatus PlayerStatus { get; private set; }

        // GUI elements
        internal GUISkin GuiSkin { get; set; }
        private GUIStyle _style;
        
        // Public accessor for GUIStyle with lazy initialization
        public GUIStyle Style
        {
            get
            {
                if (_style == null)
                {
                    _style = new GUIStyle
                    {
                        normal =
                        {
                            textColor = Color.red,
                            background = Texture2D.whiteTexture
                        }
                    };
                }
                return _style;
            }
        }

        // Cheat toggles
        internal bool MobESP { get; set; } = false;
        internal bool ChestESP { get; set; } = false;

        // Cached reference to main camera
        private Camera _mainCamera;

        // Private constructor to enforce singleton usage
        private GlobalVariables() { }

        /// <summary>
        /// Retrieves (and caches) the PlayerStatus singleton instance, if not already set.
        /// </summary>
        public PlayerStatus GetPlayerStatus()
        {
            // If PlayerStatus is not set, fetch from the actual PlayerStatus singleton
            if (PlayerStatus == null)
            {
                PlayerStatus = PlayerStatus.Instance;
            }
            return PlayerStatus;
        }

        /// <summary>
        /// Checks whether our GlobalVariables instance is null. This should always be false
        /// given the static initialization, but kept for consistency if needed.
        /// </summary>
        public static bool IsNull() => Instance == null;

        /// <summary>
        /// Logs a message with a red background in the Unity console (via BepInEx logger).
        /// </summary>
        public void Log(string message)
        {
            // If you really want the console background color changed in a standard .NET console,
            // this won't necessarily affect Unity's console, only real system console.
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Logger.LogInfo(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Returns the main camera. If not found or set, retrieve Camera.main.
        /// </summary>
        public Camera GetMainCamera()
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
                if (_mainCamera == null)
                {
                    // Log or handle the fact that Camera.main is not found
                    Log("Warning: Main Camera not found.");
                }
            }
            return _mainCamera;
        }
    }
}
﻿
