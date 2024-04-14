
Class Descriptions:


SoundFxManager:

Overview
	The SoundFxManager class is a Singleton that manages sound effects and audio in the game. It provides a centralized interface for playing WAV or OGG files. 
	This class ensures that only one instance exists throughout the game and persists between scene changes.

Usage
	To access the SoundFxManager, developers can refer to it using SoundFxManager.Instance.

Members

	soundFXobj: An AudioSource component used to play sound effects.

	Instance: A static reference to the singleton instance of the SoundFxManager.

	Awake(): Initializes the singleton instance of the SoundFxManager and ensures that it persists between scene changes.

	playSFX(): Method to play a sound effect. It takes an AudioClip to play, a Transform to spawn the sound effect, and a volume level.


IMPORTANT!!!!!!
	Currently, only WAV and OGG files are supported for sound effects in Unity. MP3 files are not supported.



ChatNode:

Overview
	The ChatNode class represents a node in a dialogue graph. Each node contains text representing the dialogue spoken by a character and a list of possible responses that lead to the next node in the conversation.
	text: A string representing the dialogue spoken by the character associated with this node.
	responses: A list of Response objects representing the possible responses that lead to the next node in the conversation.
Members
	text: A string representing the dialogue spoken by the character associated with this node.
	responses: A list of Response objects representing the possible responses that lead to the next node in the conversation.





Response:


Overview
	The Response class is used in a dialogue graph to hold references to the next node in the conversation. It represents a response option that the player or character can choose during a dialogue interaction.
Members
	text: A string representing the text of the response.
	nextNode: A reference to the next ChatNode in the conversation.


ChatSys:

Overview
	The ChatSys class is responsible for managing the dialogue system in the game. It contains functions to initialize the dialogue,
	update the UI with dialogue text and response options, handle player choices, and control the flow of the conversation using ChatNode and Response objects.
Members
	chatText: A reference to the UI Text component used to display dialogue text.
	optionButtons: An array of UI Button components representing response options.
	currentNode: A reference to the current node in the dialogue graph.
	initNode, aboutNode, saleNode, exitNode: References to specific nodes in the dialogue graph representing different conversation paths.
 Notes
	The class contains methods to handle dialogue initialization, updating UI, processing player choices, and exiting the dialogue.
	I'm sorry to whoever has to fix the "graph" implementation... good luck 



NPC


Overview
	The NPC class is responsible for controlling the behavior of non-player character (NPC) game objects in the game. 
	It handles collision detection with other game objects, controls sprite movement, and initiates dialogue interactions with the player using the chat system.

Members
	sfxClip: AudioClip for playing sound effects associated with the NPC.
	flipSpeed: Speed at which the NPC flips direction.
	chatSys: Reference to the ChatSys component for initiating dialogue interactions.
	flipTimer: Timer for controlling sprite flip frequency.
	datChat: Reference to the chat UI GameObject.
	player: Reference to the player GameObject.
Methods
	Start(): Initializes the NPC object.
	Update(): Updates the NPC's behavior each frame.
	OnCollisionEnter2D(Collision2D collision): Handles collision detection with other game objects.
Notes
	The class utilizes Unity's MonoBehaviour lifecycle methods such as Start() and Update() for initialization and updating behavior.
	It handles collision detection using the OnCollisionEnter2D method to trigger dialogue interactions with the player and sound effects.
	The NPC's movement logic is controlled in the Update() method, flipping its sprite direction at a specified frequency.




NPCSys:

Overview
	The NPCSys private data pattern class, responsible for holding data about each NPC in the game. It stores information such as the NPC's name, affinity level, and position coordinates.


Members
	name: Name of the NPC.
	affinity: Affinity level of the NPC.
	posX, posY: Position coordinates of the NPC.
	Constructors: Overloaded constructors to initialize the NPCSys object with or without parameters.
	Getters: Method to retrieve the affinity value.
	Setters: Methods to update the affinity value, position coordinates, and NPC name.
Methods
	GetAffinity(): Retrieves the affinity level of the NPC.
	SetAffinity(int x): Sets the affinity level of the NPC.
	SetPos(int x, int y): Sets the position coordinates of the NPC.
	SetName(string newName): Sets the name of the NPC.
Additional Notes
	The class provides constructors to initialize NPCSys objects with default values or specified parameters.
	It includes getter and setter methods to access and update the NPC's attributes.
	The position coordinates are represented by integer values posX and posY, indicating the NPC's position on a 2D grid or map.