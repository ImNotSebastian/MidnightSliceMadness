using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*****************************************************************************
 *NPC: Responsible for npc behaviour
 * -  (collision sprite movement, calling the chatui)
 *  
 *  
 *
 *  
 *
 *****************************************************************************/
public class NPC : MonoBehaviour
{

    [SerializeField]
    private AudioClip sfxClip;

    private int flipTimer = 0;
    private GameObject datChat;


    [SerializeField]
    private int flipSpeed = 500;

    [SerializeField]
    private ChatSys chatSys;







    // Start is called before the first frame update
    void Start()
    {
        //Need reference to chatUI & chatSys to activate them
        datChat = GameObject.Find("ChatUI");

        chatSys = datChat.GetComponent<ChatSys>(); //call function to find ChatSys

        if (chatSys == null)
        {
            Debug.Log($"NPC failed to find chat System class");
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (flipTimer > flipSpeed)
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
        GameObject player = GameObject.Find("PlayerBicycle");

        if (collision.gameObject == player)
        {//start dialogue
            chatSys.StartDialogue();
        }

        if (sfxClip == null)
        {
            Debug.LogError("sfxClip is not assigned in the inspector.");
        }
        else
        {
            //example of sfx call
            SoundFxManager.Instance.playSFX(sfxClip, transform, 1f);
        }
    }




    //check out building 2d settings

}
