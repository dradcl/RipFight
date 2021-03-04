using System;
using MelonLoader;
using UnityEngine;

namespace RipFight
{
    public class MainMod : MelonMod
    {
        private int levelNum;
        private Gravity gravity;
        private Crown crown;
        private Controller player;
        private GameManager gameManager;
        private MultiplayerManager multiplayerManager;
        private SteamStatsAndAchievements steamStats;
        private Weapon weapon;
        private Transform[] transform;

        private float playerZ;
        private float playerY;

        public override void OnUpdate()
        {
            if (levelNum > 0 && player && !player.inactive)
            {
                //crown.SetNewKing(player, true);
                
                //player.Jump();
            }

            // (N) Spawn A Dummy Player
            if (Input.GetKeyDown(KeyCode.N))
            {
                multiplayerManager.SpawnPlayerDummy(10);
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

            // (Z) Teleport character to mouse position
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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

                player = UnityEngine.Object.FindObjectOfType<Controller>();

                foreach (Rigidbody rigidbody in player.movement.rigidbodies)
                {
                    rigidbody.position = new Vector3(0, playerY, playerZ);
                }
            }
        }

        public override void OnSceneWasInitialized(int level, string sceneName)
        {
            levelNum = level;

            //player = UnityEngine.Object.FindObjectOfType<Controller>();
            transform = UnityEngine.Object.FindObjectsOfType<Transform>();
            //InitializeGameObjects();

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
            // reminder u cant modify weapon ammo shitz
            //weapon = UnityEngine.Object.FindObjectOfType<Weapon>();
        }

    }
}