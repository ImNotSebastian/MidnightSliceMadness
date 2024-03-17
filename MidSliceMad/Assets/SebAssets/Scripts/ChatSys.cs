using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSys : MonoBehaviour
{
   //dialogue vars
	public Text chatText;
    public Button[] optionButtons;

    private ChatNode currentNode;
	
	
	
	 // Start is called before the first frame update
    void Start()
    {
    	// Find and assign references to UI elements using GetComponent
    	
        chatText = GameObject.Find("Prompt").GetComponent<Text>(); 
        optionButtons = new Button[4]; // Assuming you have 4 response option buttons

        for (int j = 1; j < optionButtons.Length; j++)
		{
			//Debug.LogError(j); //if null, log it ws not found
    		string buttonName = "Reply (" + j + ")"; //assign button name to string
    		 
   			GameObject buttonGO = GameObject.Find(buttonName); //call function to find button
   			 
   			if (buttonGO != null)
   			{
       			 optionButtons[j] = buttonGO.GetComponent<Button>(); //assign to list if not null
    		}
    		else
   		    {
        		Debug.LogError("Button not found: " + buttonName); //if null, log it ws not found
    		}
		}  
  
    }

	
	
	/*dialogue functions*/
	
	public void StartDialogue()
    {
        // Initialize the dialogue by showing the first node
        currentNode = GetInitialNode();
        UpdateUI();
    }

    private void UpdateUI()
    {
      //  Debug.Log("Chat Text: " + chatText.text); // Check if chatText is null pre update
		chatText.text = currentNode.text; // Attempt to update text
		//Debug.Log("Chat Text: " + chatText.text); // Check if chatText is null post update

        // Update the response buttons
        for (int i = 1; i < optionButtons.Length; i++)
        {
            if (i < currentNode.responses.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                
                
                optionButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = currentNode.responses[i].text;
                
                // Capture the index in a local variable for use in the button click event
                int index = i;   
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => ChooseOption(index));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void ChooseOption(int index)
    {
        if (index < currentNode.responses.Count)
        {
            // Update the current node based on the chosen response
            currentNode = currentNode.responses[index].nextNode;
            UpdateUI();
        }
        
        //exit the system
        if(currentNode.text == "Goodbye!")
        {
        	ExitDialogue();
        }
    }

    private ChatNode GetInitialNode()
    {
        // Logic to determine the initial node of the dialogue
        
        // For simplicity, return a hardcoded initial node, will serialize or setter function
        ChatNode initialNode = new ChatNode();
        initialNode.text = "Hello there! What would you like to talk about?";
        initialNode.responses.Add(new Response("Tell me about yourself", GetAboutNode()));
        initialNode.responses.Add(new Response("What do you have for sale?", GetSaleNode()));
        initialNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option
        return initialNode;
    }


    private ChatNode GetAboutNode()
    {
        // Logic to create the node about the NPC
        // For simplicity, return a hardcoded node,  will serialize or setter function
        ChatNode aboutNode = new ChatNode();
        aboutNode.text = "I'm just a humble merchant traveling these lands.";
        aboutNode.responses.Add(new Response("Lame...", GetInitialNode()));
        aboutNode.responses.Add(new Response("What do you have for sale?", GetSaleNode()));
        aboutNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option
        return aboutNode;
    }


//Will add to merchant (NPC child) once parent class is working
//Need to add LastNode to finish conversations

    private ChatNode GetSaleNode()
    {
        // Logic to create the node about available items for sale
        // For simplicity, return a hardcoded node,  will serialize or setter function
        ChatNode saleNode = new ChatNode();
        saleNode.text = "Take a look at my wares!";
        return saleNode;
    }

	
	private ChatNode GetExitNode()
	{
   	 ChatNode exitNode = new ChatNode();
   	 exitNode.text = "Goodbye!";
   	 return exitNode;
	}
   
   private void ExitDialogue()
   {
    	// Deactivate the dialogue UI GameObject
    //	GameObject.SetActive(false);
   }
   
}
