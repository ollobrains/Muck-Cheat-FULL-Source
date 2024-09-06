# Muck Cheat

**Muck Cheat** is a cheat mod developed for the game **Muck**. This mod provides various in-game advantages, including the ability to see enemies (ESP), teleport to specific locations, and gain full control over player health.

## Features

- **Mob ESP:** Displays the positions of enemies on the screen.
- **RayCast Teleport:** Instantly teleport to the point where your camera is looking.
- **Player Status Control:** Manage and adjust player statuses such as health and stamina.
- **Cheat Menu:** A GUI menu where you can toggle cheats and modify player statuses.

## Installation and Compilation

To compile and run this project on your local machine, follow the steps below.

### Requirements

- **Unity**: Since this mod is Unity-based, Unity must be installed.
- **BepInEx**: BepInEx framework is used for mod development in Unity games.
- **Visual Studio** or **Rider**: An IDE is required to compile C# projects.

### Compilation Steps

1. **Clone the Project:**

   ```bash
   git clone https://github.com/your-username/MuckCheat.git
   cd MuckCheat
   ```

2. **Set Up BepInEx References:**
   - Download the BepInEx API and add it as a reference to your project. Add the BepInEx DLL files to the `References` folder of your project.
   - Reference Unity and the game DLL files (usually `GameAssembly.dll`, `UnityEngine.dll`, etc.) in your project.

3. **Compile the Project:**
   - Open the project in your IDE.
   - Select the **Build** option and compile the project. The output file (DLL) will be automatically placed in the BepInEx plugins folder.

### Installation and Usage

1. **Install the Mod:**
   - Place the compiled DLL file into the `Muck/BepInEx/plugins/` folder.
   - Ensure that BepInEx and Unity hooks are working correctly.

2. **Launch the Game:**
   - Start the game and check the console for the message "MuckCheat loaded!" to verify the mod has been loaded.

3. **Using the Cheat:**
   - Press the [C] key during the game to open the GUI.
   - In the menu, you can toggle cheats and manage player status.

## Usage Details

### Controls

- **Mob ESP:** Toggle the "Toggle mob ESP" option to see enemy positions.
- **RayCast Teleport:** Press the [C] key to teleport to where you are looking.
- **Health and Stamina:** Use the sliders in the menu to adjust the player's health and stamina.

### Important Notes

- **Use cheats responsibly.** Cheating can go against the nature of the game and negatively affect the experience of other players.
- **Updates:** Keep the mod updated to ensure compatibility with game updates.

## Contributing

If you would like to contribute to this project, star this repo and please submit a pull request or fork the project and work on it. All contributions are welcome!

## Legal Disclaimer

This mod is not supported or endorsed by the original developers of the game. The use of this mod is at your own risk. Do not violate the game's rules, and be aware of the potential consequences of using mods.

## License

This project is licensed under the MIT License - see the `LICENSE` file for details.
