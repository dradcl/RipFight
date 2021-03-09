using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RipFight
{
    public class Helper
    {
        public static string PlayerListToString()
        {
            string playerResult = "";

            foreach (Controller player in MainMod.playerList)
                playerResult += player.name + "\n";

            return playerResult;
        }
    }
}