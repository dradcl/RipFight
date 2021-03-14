namespace RipFight
{
    public sealed class Helper
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
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i].ToLower() == weaponName)
                {
                    return i;
                }
            }

            return 0;
        }
        //hehe yes the good ol copy pasta :kekw:
        public static int Camera(string cameratype)
        {
            for (int i = 0; i < Cameratype.Length; i++)
            {
                if (Cameratype[i].ToLower() == cameratype)
                {
                    return i;
                }
            }
            return 0;
        }
        public static string[] Cameratype = new string[4]
        {
           "Game",
           "SceneView",
           "Preview",
           "VR"

        };

        // Some indices are unused. They still work when called, but they are not a unique weapon.
        public static string[] weapons = new string[64]
               {
            "Pistol",
            "AK47",
            "Sword",
            "GrenadeLauncher",
            "BlinkDagger",
            "Sniper",
            "Revolver",
            "FreezeShooter",
            "RiotShield",
            "Fan",
            "Shotgun",
            "BallOfDoom",
            "ThrustCannon",
            "BowAndArrow",
            "MachineGun",
            "Lightsaber",
            "Uzi",
            "SilentMinigun",
            "MiniMinigun",
            "Minigun",
            "RicochetRifle",
            "StasisGun",
            "Bazooka",
            "Flamethrower",
            "SnakeRevolver",
            "SnakeGrenadeLauncher",
            "SnakeBazooka",
            "GlueGun",
            "LaserRocketLauncher",
            "GoldSword",
            "GoldMinigun",
            "GoldPistol",
            "CarbineRifle",
            "SnakeMinigun",
            "LavaWhip",
            "LavaBeam",
            "LavaShooter",
            "SnakeShotgun",
            "LavaGrenadeLauncher",
            "SpartanLaser",
            "LavaPistol",
            "BlackHoleCannon",
            "BossTriShot",
            "BossRazorShield",
            "BossTriBeam",
            "UnusedIndex1",
            "BossPulseLauncher" ,
            "BossShooter",
            "BossBurstShooter",
            "BossWallmaker",
            "UnusedIndex2",
            "UnusedIndex3",
            "UnusedIndex4",
            "UnusedIndex5",
            "BossDubstepGun",
            "BossRainbowSlowshot",
            "UnusedIndex6",
            "UnusedIndex7",
            "BossBounceshot",
            "PumpkinLauncher",
            "BurstRifle",
            "DesertEagle",
            "SawedOffShotgun",
            "Spear"
               };
    }
}
