using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChatTree
{
    private ChatNode head;
	
	public ChatTree()
	{
		this.head = null;
		
	}
	
	public bool empty()
	{
		return (this.head == null);
	}
}
