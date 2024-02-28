using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNode 
{
	//replies
	private string message;
	private string[] replies = {"1","2","3","4"};
	
	
	//Nodes
	private ChatNode nextOne;
	private ChatNode nextTwo;
	private ChatNode nextThree;
	private ChatNode nextFour;



	// Parameterized Constructor
	public ChatNode(string message, string[] replies, ChatNode nextOne, ChatNode nextTwo, ChatNode nextThree, ChatNode nextFour)
	{
		this.message = message;
		this.replies = replies;
		this.nextOne = nextOne;
		this.nextTwo = nextTwo;
		this.nextThree = nextThree;
		this.nextFour = nextFour;
	}



    // Getter and Setter for message
    public string Message
    {
        get { return message; }
        set { message = value; }
    }

    // Getter and Setter for replies
    public string[] Replies
    {
        get { return replies; }
        set { replies = value; }
    }

    // Getter and Setter for Nodes
    public ChatNode NextOne
    {
        get { return nextOne; }
        set { nextOne = value; }
    }

    public ChatNode NextTwo
    {
        get { return nextTwo; }
        set { nextTwo = value; }
    }

    public ChatNode NextThree
    {
        get { return nextThree; }
        set { nextThree = value; }
    }

    public ChatNode NextFour
    {
        get { return nextFour; }
        set { nextFour = value; }
    }


}
