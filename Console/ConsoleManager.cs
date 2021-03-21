using MelonLoader;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RipFight.Console
{
    public sealed class ConsoleManager
    {
        private string[] commands = new string[5] { "init", "summon", "unlockachievements", "give", "map" };
        private RFLevelManager rfLevelManager = new RFLevelManager();

        public GUIStyle consoleStyle = new GUIStyle()
        {
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState()
            {
                textColor = Color.white,            
            }
        };

        public string currentCommand = "";
        public string lastCommand = "";
        public enum CommandStatus
        {
            Success,
            NotFound,
            Error
        }

        public CommandStatus SubmitCommand(string command)
        {
            string[] commandArgs = currentCommand.ToLower().Split(' ');

            if (commands.Contains(commandArgs[0]))
            {
                switch (commandArgs[0])
                {
                    case "init":
                        Initialize();
                        break;
                    case "summon":
                        switch(commandArgs[1])
                        {
                            case "pawn":
                                if (commandArgs.Length > 2)
                                    SummonPawn(commandArgs[2]);
                                else
                                    SummonPawn("default");
                                break;
                        }
                        break;
                    case "unlockachievements":
                        UnlockAchievements();
                        break;
                    case "give":
                        MainMod.players[0].fighting.PickUpWeapon(Helper.MatchIDToWeapon(commandArgs[1]), null);
                        break;
                    case "map":
                        MainMod.gameManager.StartMatch(rfLevelManager.GetMapByName(commandArgs[1]), true);
                        break;
                    default:
                        break;
                }

                MelonLogger.Msg($"Ran command: \"{command}\"");
                lastCommand = command;
                return CommandStatus.Success;
            }

            MelonLogger.Msg($"Command not found: \"{command}\"");
            return CommandStatus.NotFound;
        }

        public void Initialize()
        {
            MainMod.players = UnityEngine.Object.FindObjectsOfType<Controller>();
            MainMod.gameManager = UnityEngine.Object.FindObjectOfType<GameManager>();
            MainMod.multiplayerManager = UnityEngine.Object.FindObjectOfType<MultiplayerManager>();
            MainMod.steamStats = UnityEngine.Object.FindObjectOfType<SteamStatsAndAchievements>();
    }

        private void SummonPawn(string color)
        {
            // Defaults at 3 (green)
            byte spawnColor = 3;

            switch (color)
            {
                case "yellow":
                    spawnColor = 0;
                    break;
                case "blue":
                    spawnColor = 1;
                    break;
                case "red":
                    spawnColor = 2;
                    break;
            }

            MainMod.playerList.Add(MainMod.multiplayerManager.SpawnPlayerDummy(spawnColor, MainMod.worldPosition).GetComponent<Controller>());
        }

        private void LoadMap()
        {
            SceneManager.LoadScene("Woods2");
        }

        private void UnlockAchievements()
        {
            foreach (SteamStatsAndAchievements.EAchievement eAchievement in Enum.GetValues(typeof(SteamStatsAndAchievements.EAchievement)))
            {
                MainMod.steamStats.UnlockAchievement(eAchievement);
                MelonLogger.Msg($"Unlocked: {eAchievement.ToString()}");
            }
        }
    }
}