using MelonLoader;
using UnityEngine;
using System.Collections.Generic;
using RipFight.Console;
using System;

namespace RipFight
{
    public class MainMod : MelonMod
    {
        private int levelNum; // Not used atm, but saved just in case.
        public static Vector3 worldPosition;
        public Discord.Discord discordRPC;

        private bool listIsOpen = false;
        private bool consoleIsOpen = false;

        // This spot is dedicated to IS KING!!
        public static Controller player;
        public static GameManager gameManager;
        public static MultiplayerManager multiplayerManager;
        public static SteamStatsAndAchievements steamStats;
        public static Weapon weapon;
        public static Transform[] transform;
        public static Explosion implode;
        private ConsoleManager consoleManager = new ConsoleManager();
        private ControllerHandler controllerHandler;

        public static Controller[] players;
        public static List<Controller> playerList = new List<Controller>();

        public override void OnApplicationStart()
        {
            discordRPC = new Discord.Discord(819053346207039498, (ulong)Discord.CreateFlags.Default);
        }

        public override void OnGUI()
        {
            if (listIsOpen)
            {
                GUI.TextArea(new Rect(0, 300, 300, 300), Helper.PlayerListToString());
            }

            if (consoleIsOpen)
            {
                GUI.Box(new Rect(0, Screen.height - 100, Screen.width, 50), "");
                consoleManager.currentCommand = GUI.TextField(new Rect(0, Screen.height - 100, Screen.width, 50), consoleManager.currentCommand, 30);
            }
        }
        public override void OnUpdate()
        {
            discordRPC.RunCallbacks();

            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (consoleIsOpen && Input.GetKeyDown(KeyCode.Return))
            {
                consoleManager.SubmitCommand(consoleManager.currentCommand);
                consoleManager.currentCommand = "";
            }

            if (consoleIsOpen && Input.GetKeyDown(KeyCode.UpArrow))
            {
                consoleManager.currentCommand = consoleManager.lastCommand;
            }

            // Use KeyCode.BackQuote in final.
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                consoleIsOpen = !consoleIsOpen;
            }

            // (Z) Teleport character to mouse position
            if (Input.GetKeyDown(KeyCode.Z))
            {
                foreach (Rigidbody rigidbody in players[0].movement.rigidbodies)
                {
                    rigidbody.position = new Vector3(0, worldPosition.y, worldPosition.z);
                }
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                listIsOpen = !listIsOpen;
            }
        }

        // SUS
        public override void OnSceneWasInitialized(int level, string sceneName)
        {
            controllerHandler = UnityEngine.Object.FindObjectOfType<ControllerHandler>();

            int playerCount = controllerHandler.ActivePlayers.Count; 
            string gameState = "Game";

            if (sceneName == "MainScene" && !MatchmakingHandler.IsNetworkMatch)
            {
                playerCount = 1; // Since the Controller in the lobby is not initialized until player input, this will just be set to 1
                gameState = "Lobby";
            }
                
            Discord.ActivityManager activityManager = discordRPC.GetActivityManager();
            Discord.Activity activity = new Discord.Activity
            {
                State = $"Playing on {sceneName}",
                Details = $"In {gameState} ({playerCount} / 4)",
                Timestamps =
                {
                    Start = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, // unix time conversion
                },
                Assets =
                {
                    LargeImage = "ripfightlogo",
                    LargeText = "By: Karma Kitten & M1",
                    SmallImage = "crown",
                    SmallText = "IS KING",
                },
            };

            activityManager.UpdateActivity(activity, result =>
            {
                MelonLogger.Msg($"Activity was updated. Status: {result}");
            });

            levelNum = level;
            MelonLogger.Msg($"Level {sceneName} was loaded");
        }
    }
}