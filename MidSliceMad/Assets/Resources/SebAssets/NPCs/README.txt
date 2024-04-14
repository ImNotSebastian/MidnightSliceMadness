Prefab Descriptions:

NPC:

	The base prefab for the npc objects. 
	This prefab, and its variants contain the folowing components:
		Transform, Rigidbody2d, BoxCollider2d, NPC (Script), and Sprite Renderer

		NPC Script: requires 2 serialized fields to be declared before they can execute properly.
		An Audio Clip (.wav or .ogg) and the ChatUI from the inspector in the ChatSys field.

		Currently npc's have to be manually placed through the inspector, attempted to make a factory
		but it caused errors with the UI system, so the factory was scraped.

		All prefabs are identical to the base npc, besides their sprite, and boxcollider dimensions.
		So their descriptions will describe the character

HutTheHut:  Antagonist of the game.
		

NPC Variant:  A generic NPC, who is not capable of time travel

PB Variant:   The love interest, a mycelium with a big heart, and beautiful lips

Turtle Variant:   An adolescent genetically altered Ronin Turtle