using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Name:Sebastian Fedane
Role: Team Lead 1 -- IT Manager
Project: Midnight Slice Madness
This file contains the chat node class
It holds a string for the npc text, and a list of response options
Response options hold the references to the next nodes
*/


public class ChatNode
{
    public string text;
    public List<Response> responses = new List<Response>();

 
}

