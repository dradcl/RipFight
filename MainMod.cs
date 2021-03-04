using System;
using MelonLoader;
using UnityEngine;

namespace RipFight
{
    public class MainMod : MelonMod
    {
        private Vector3 spawnLocation = new Vector3(0, 0, 0);
        private int levelNum;
        private Gravity gravity;
        private Crown crown;
        private Controller player;
        private GameManager gameManager;
        private MultiplayerManager multiplayerManager;
        private SteamStatsAndAchievements steamStats;
        private Weapon weapon;
        private MultiplayerManager MPM;



        public override void OnUpdate()
        {
            if (levelNum > 0 && player && !player.inactive)
            {
                //crown.SetNewKing(player, true);
                
                //player.Jump();
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                // Summons a Dummy Player
                MPM.SpawnPlayerDummy(10);
                MelonLogger.Msg("Summoned Pawn");
            }
            // (T) Achievement Unlocks
            if (Input.GetKeyDown(KeyCode.T))
            {
                foreach (SteamStatsAndAchievements.EAchievement eAchievement in Enum.GetValues(typeof(SteamStatsAndAchievements.EAchievement)))
                {
                    steamStats.UnlockAchievement(eAchievement);
                    MelonLogger.Msg($"Unlocked: {eAchievement.ToString()}");

                }
            }
        }


        public override void OnSceneWasInitialized(int level, string sceneName)
        {
            InitializeGameObjects();
            levelNum = level;

            MelonLogger.Msg($"Level {sceneName} was loaded");
        }

        private void InitializeGameObjects()
        {
            //gravity = UnityEngine.Object.FindObjectOfType<Gravity>();
            player = UnityEngine.Object.FindObjectOfType<Controller>();
            crown = UnityEngine.Object.FindObjectOfType<Crown>();
            gameManager = UnityEngine.Object.FindObjectOfType<GameManager>();
            multiplayerManager = UnityEngine.Object.FindObjectOfType<MultiplayerManager>();
            steamStats = UnityEngine.Object.FindObjectOfType<SteamStatsAndAchievements>();
            MPM = UnityEngine.Object.FindObjectOfType<MultiplayerManager>();
            // reminder u cant modify weapon ammo shitz
            // weapon = UnityEngine.Object.FindObjectOfType<Weapon>();
        }

    }
}
