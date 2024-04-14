using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*****************************************************************************
 *Response: Used for dialogue graph
 * - Holds the references to the next node
 *  
 *  ChatNode contains array of responses
 *
 *  
 *
 *****************************************************************************/
public class Response
{
    public string text;
    public ChatNode nextNode;

    public Response(string text, ChatNode nextNode)
    {
        this.text = text;
        this.nextNode = nextNode;
    }

    // Method to update the text of the response
    public void UpdateText(string newText)
    {
        text = newText;
    }
}