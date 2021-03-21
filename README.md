# RipFight
A simple console for [Stick Fight](https://store.steampowered.com/app/674940/Stick_Fight_The_Game/) with custom commands. Based on [MelonLoader](https://melonwiki.xyz/#/).  
![image](https://cdn.discordapp.com/app-icons/819053346207039498/ff974a04c90c177827f8aea0ce7e9c43.png)

# Usage
Load into a match (or lobby) and press TAB to open the console. A list of commands can be found in [Features](#features)

# Features
- Fully custom console with commands.
- Player teleport to mouse, press Z.
- Discord Rich Presence with game data.  
![image](https://media.discordapp.net/attachments/630277945507708928/821564462443266078/unknown.png)  
- Re-enter the most recent command, press up arrow.

__Commands List__:  
-``summon pawn`` (default,red,blue, or yellow) - Summons dummy pawns that you can hit  
-``unlockachievements`` - Unlocks all the steam achievements  
-``give {Weapon Name}`` - Gives the player a weapon (weapons are in weapons.txt)  
-``init`` - Initializes game objects manually, only use if it fails to do so automatically.  
-``map {Map Name}`` - Changes the map. Only works locally for now. (maps are in maps.txt)  

# Installation
1. Download [MelonLoader](https://melonwiki.xyz/#/?id=requirements) and follow the automated installation instructions.  
2. Make sure you go to the settings tab in MelonLoader and enable "Show ALPHA Pre-Releases", then set the "Game Arch" to x86 before you click install.  
3. Naviagte here in your install of Stick Fight: ``StickFightTheGame\StickFight_Data\Managed``  
4. Drag and replace your ``Assembly-CSharp.dll`` with the one [here](https://github.com/karmakittenx/RipFight/tree/main/Deps)  
5. Now download the latest release of [RipFight](https://github.com/karmakittenx/RipFight/releases), drag it into the ``Mods`` folder that MelonLoader created, launch the game, and enjoy!

# Known Bugs  
- The initialized character will sometimes not be yours.  
- Sometimes objects will fail at random, check Melon Logs.
