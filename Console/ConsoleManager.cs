using MelonLoader;
using System;
using System.Linq;

namespace RipFight.Console
{
    public sealed class ConsoleManager
    {
        private string[] commands = new string[3] { "init", "summon", "unlockachievements" };

        public string currentCommand = "";
        public enum CommandStatus
        {
            Success,
            NotFound,
            Error
        }

        public CommandStatus SubmitCommand(string command)
        {
            string[] commandArgs = currentCommand.Split(' ');

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
                                IncompleteCommand();
                                break;
                            case "defaultpawn":
                                DefaultPawn();
                                break;
                            case "bluepawn":
                                BluePawn();
                                break;
                            case "redpawn":
                                RedPawn();
                                break;

                        }
                        break;
                    case "unlockachievements":
                        UnlockAchievements();
                        break;
                    default:
                        break;
                }

                MelonLogger.Msg($"Ran command: \"{command}\"");
                return CommandStatus.Success;
            }

            MelonLogger.Msg($"Command not found: \"{command}\"");
            return CommandStatus.NotFound;
        }

        private void Initialize()
        {
            MainMod.players = UnityEngine.Object.FindObjectsOfType<Controller>();
            MainMod.gameManager = UnityEngine.Object.FindObjectOfType<GameManager>();
            MainMod.multiplayerManager = UnityEngine.Object.FindObjectOfType<MultiplayerManager>();
            MainMod.steamStats = UnityEngine.Object.FindObjectOfType<SteamStatsAndAchievements>();
        }

        // modify dll for dummy position
        // click to spawn
        private void IncompleteCommand()
        {
            MelonLogger.Msg("Incomplete command try: \n Summon defaultpawn - Summons Yellow Pawn with no Physics \n summon bluepawn - Summons a Blue pawn with Physics \n summon redpawn - Summons a Red pawn with Physics");
        }
        private void DefaultPawn()
        {
            MainMod.playerList.Add(MainMod.multiplayerManager.SpawnPlayerDummy(0, MainMod.worldPosition).GetComponent<Controller>());
        }
        private void BluePawn()
        {
            MainMod.playerList.Add(MainMod.multiplayerManager.SpawnPlayerDummy(1, MainMod.worldPosition).GetComponent<Controller>());
        }
        private void RedPawn()
        {
            MainMod.playerList.Add(MainMod.multiplayerManager.SpawnPlayerDummy(2, MainMod.worldPosition).GetComponent<Controller>());
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
