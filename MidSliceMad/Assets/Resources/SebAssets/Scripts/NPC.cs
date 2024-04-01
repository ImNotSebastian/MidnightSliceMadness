using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{


	private ChatSys chatSys;
	
	//animation vars
	public Transform headCheck;
	private int flipTimer = 0;
	

	 private GameObject datChat;
   
	
	[SerializeField]
	private int flipSpeed = 500;
	
	

	
    // Start is called before the first frame update
    void Start()
    {
		 //Need reference to panel & chatUI to activate them
        datChat = GameObject.Find("ChatUI");
    	
		chatSys = datChat.GetComponent<ChatSys>(); //call function to find ChatSys
	
    }


    // Update is called once per frame
    void Update()
    {
        if(flipTimer > flipSpeed)
		{
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
			flipTimer = 0;
		}
		else
		{
			flipTimer++;
		}
    }
	
	
	
	
	
	//Upon collision with another GameObject, this GameObject will reverse direction
    protected void OnCollisionEnter2D(Collision2D collision)
    {
		 Debug.Log($"Collided with NPC.");
        //start dialogue
		chatSys.StartDialogue();
    }
	
	
	
    //check out building 2d settings
	
}
