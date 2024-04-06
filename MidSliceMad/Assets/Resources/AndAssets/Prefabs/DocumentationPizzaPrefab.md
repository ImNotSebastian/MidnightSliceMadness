# Pizza Prefab

The Pizza prefab is a GameObject with a 2D pizza sprite and the `Pizza.cs` script attached. When instantiated, the pizza will be a child of the `Inventory` object and will move with the main camera.

## Description

The Pizza prefab represents a pizza item that can be added to the player's inventory. It has a pizza sprite and the `Pizza.cs` script attached, which handles the pizza's object attributes.

When the pizza is instantiated, it will be a child of the `Inventory` object, which means it will move along with the main camera. The spawn location of the pizza can be manually adjusted by modifying the serialized fields in the `Pizza.cs` script.

## Components

1. **Sprite Renderer**:
   - Displays the 2D pizza sprite.
   - The sprite can be customized in the Inspector.

2. **Pizza.cs Script**:
   - Handles the pizza's behavior and positioning.
   - Serialized fields:
     - `spawnOffsetX`: The x-axis offset from the main camera where the pizza will spawn.
     - `spawnOffsetY`: The y-axis offset from the main camera where the pizza will spawn.
     - `spawnOffsetZ`: The z-axis offset from the main camera where the pizza will spawn.
	
## Usage

1. **Instantiate the Pizza Prefab**:
   - Drag and drop the `Pizza` prefab from the Assets folder into your scene.
   - Instantiate the pizza prefab by spawning it with a script.
      - If done this way, the pizza will be a child of the `Inventory` object and will move with the main camera.

2. **Customize the Pizza Spawn Location**:
   - In the `Pizza.cs` script, adjust the `spawnOffsetX`, `spawnOffsetY`, and `spawnOffsetZ` serialized fields to set the desired spawn location of the pizza relative to the main camera.

3. **Interact with the Pizza**:
   - The `Pizza.cs` script provides certain attributes of the pizza game objects which can cause them to act certain ways in the game.
   - Attach your own scripts to the `Inventory` object or other game objects to handle the pizza's interactions.

## Limitations

- The pizza sprite and its size are fixed and cannot be changed in game once instantiated during runtime.
- The pizza's movement is limited to the offset from the main camera and cannot be controlled independently.

## Contributing

Contributions to this prefab are welcome. Feel free to open issues or submit pull requests for improvements or additional features.

## License

This project is licensed under the the Unity Personal License.

## Acknowledgments

Thank you to Unity Technologies for hosting the prefab on their Unity game development platform.
