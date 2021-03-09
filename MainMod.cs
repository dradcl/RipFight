using MelonLoader;
using UnityEngine;
using System.Collections.Generic;
using RipFight.Console;

namespace RipFight
{
    public class MainMod : MelonMod
    {
        private int levelNum; // Not used atm, but saved just in case.
        private float playerZ;
        private float playerY;
        public static Vector3 worldPosition;

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

        public static Controller[] players;
        public static List<Controller> playerList = new List<Controller>();

        public override void OnGUI()
        {
            if (listIsOpen)
            {
                GUI.TextArea(new Rect(0, 300, 300, 300), Helper.PlayerListToString());
            }

            if (consoleIsOpen)
            {
                GUI.Box(new Rect(0, Screen.height - 100, Screen.width, 50), "");
                consoleManager.currentCommand = GUI.TextField(new Rect(0, Screen.height - 100, Screen.width, 50), consoleManager.currentCommand, 20);
            }
        }
        public override void OnUpdate()
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (consoleIsOpen && Input.GetKeyDown(KeyCode.Return))
            {
                consoleManager.SubmitCommand(consoleManager.currentCommand);
                consoleManager.currentCommand = "";
            }

            // Use KeyCode.BackQuote in final.
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                consoleIsOpen = !consoleIsOpen;
            }

            // (Z) Teleport character to mouse position
            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerZ = worldPosition.z;
                playerY = worldPosition.y;

                if (playerZ > 0)
                    playerZ -= 1.8f;
                else
                    playerZ += 1.8f;

                if (playerY > 0)
                    playerY -= 2.0f;
                else
                    playerY += 2.0f;

                foreach (Rigidbody rigidbody in players[0].movement.rigidbodies)
                {
                    rigidbody.position = new Vector3(0, playerY, playerZ);
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
            levelNum = level;
            MelonLogger.Msg($"Level {sceneName} was loaded");
        }
    }
}