using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	
	private DialogueBox chatBox;
	
	
	
	public Transform headCheck;
	
	
	private int flipTimer = 0;
	
	[SerializeField]
	private int flipSpeed = 500;
	
	
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        
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
	
	/*
	private bool isCollidingWithPlayer()
	{
		return Physics2D.OverlapCircle(headCheck.position, 0.2f, PlayerBicycle);
	}
	*/
	
}
