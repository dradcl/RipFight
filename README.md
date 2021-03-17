# RipFight
A simple console for [Stick Fight](https://store.steampowered.com/app/674940/Stick_Fight_The_Game/) with custom commands. Based on [MelonLoader](https://melonwiki.xyz/#/).

# Usage
Load into a match (or lobby) and press TAB to open the console. A list of commands can be found in [Features](#features)

# Features
- Fully custom console with commands.
- Player teleport to mouse, press Z.
- Discord Rich Presence with game data.  
![image](https://media.discordapp.net/attachments/630277945507708928/821564462443266078/unknown.png)  
- Re-enter the most recent command, press up arrow.

__Commands List__:  
-``summon pawn`` (default,red,blue, or yellow) - summons dummy pawns that you can hit  
-``unlockachievements`` - Unlocks all the steam achievements  
-``give`` (weapon) - gives the player a weapon (weapons are in weapons.txt, make sure its all lowercase)  
-``init`` - initializes game objects manually, only use if it fails to do so automatically.  
-``map`` - Soon

# Known Bugs  
- The initialized character will sometimes not be yours.  
- Sometimes objects will fail at random, check Melon Logs.
