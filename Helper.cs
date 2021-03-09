using System;

namespace RipFight
{
    public class Helper
    {
        public static string[] playerColors = { "default", "blue", "red" };
        public static string PlayerListToString()
        {
            string playerResult = "";

            foreach (Controller player in MainMod.playerList)
                playerResult += player.name + "\n";

            return playerResult;
        }

        public static int MatchIDToWeapon(string weaponName)
        {
            string[] weapons = Enum.GetNames(typeof(Weapons));
            
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i].ToLower() == weaponName)
                {
                    return i;
                }
            }

            return 0;
        }

        private enum Weapons
        {
            Pistol,
            AK47,
            Sword,
            GrenadeLauncher,
            BlinkDagger,
            Sniper,
            Revolver,
            FreezeShooter,
            RiotShield,
            Fan,
            Shotgun,
            BallOfDoom,
            ThrustCannon,
            BowAndArrow,
            MachineGun,
            Lightsaber,
            Uzi,
            SilentMinigun,
            MiniMinigun,
            Minigun,
            RicochetRifle,
            StasisGun,
            Bazooka,
            Flamethrower,
            SnakeRevolver,
            SnakeGrenadeLauncher,
            SnakeBazooka,
            GlueGun,
            LaserRocketLauncher,
            GoldSword,
            GoldMinigun,
            GoldPistol,
            CarbineRifle,
            SnakeMinigun,
            LavaWhip,
            LavaBeam,
            LavaShooter,
            SnakeShotgun,
            LavaGrenadeLauncher,
            SpartanLaser,
            LavaPistol,
            BlackHoleCannon,
            BossTriShot,
            BossRazorShield,
            BossTriBeam,
            BossPulseLauncher = 46,
            BossShooter,
            BossBurstShooter,
            BossWallmaker,
            BossDubstepGun = 54,
            BossRainbowSlowshot,
            BossBounceshot = 58,
            PumpkinLauncher,
            BurstRifle,
            DesertEagle,
            SawedOffShotgun,
            Spear
        }
    }
}