using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSys : MonoBehaviour
{

    // Define a maximum depth for the dialogue tree to prevent overflow, can be used for tests
    private int maxDepth = 10; 
    private int currentDepth = 0;


    //dialogue vars
    public Text chatText;
    public Button[] optionButtons;

    //got rid of graph structure
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

        // Reset the current depth when starting a new dialogue
        currentDepth = 0;
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

        // Increment the depth counter upon choosing an option
        currentDepth++;

        // Check if the depth limit has been reached
        if (currentDepth >= maxDepth)
        {
            // Terminate if depth of graph gets too big
              Debug.Log("Chat Graph exceeded max size, exiting dialogue"); 
            ExitDialogue();
            return;
        }

        if (index < currentNode.responses.Count)
        {
            // Update the current node based on the chosen response
            currentNode = currentNode.responses[index].nextNode;
            UpdateUI();
        }
        
        //exit the system, if goodbye node is chosen
        if(currentNode.text == "Goodbye!")
        {
        	ExitDialogue();
        }
    }

    private ChatNode GetInitialNode()
    {
        // Hard coded introduction node
        // For simplicity, return a hardcoded node,  will serialize or use setter function
        ChatNode initialNode = new ChatNode();
        initialNode.text = "Do you have my Pizza.";
        initialNode.responses.Add(new Response("Tell me about yourself", GetAboutNode()));
        initialNode.responses.Add(new Response("Heres your Pizza", GetSaleNode()));
        initialNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option
        return initialNode;
    }


    private ChatNode GetAboutNode()
    {
        // Hard coded node for about the npc
        // For simplicity, return a hardcoded node,  will serialize or use setter function
        ChatNode aboutNode = new ChatNode();
        aboutNode.text = "Nun-ya";
        aboutNode.responses.Add(new Response("Nice to meet you Nun-ya.", GetInitialNode()));
        aboutNode.responses.Add(new Response("What do you have for sale?", GetSaleNode()));
        aboutNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option
        return aboutNode;
    }


//Will add to merchant (NPC child) once parent class is working
//Need to add LastNode to finish conversations

    private ChatNode GetSaleNode()
    {
        // Hard coded transaction node
        // For simplicity, return a hardcoded node,  will serialize or use setter function
        ChatNode saleNode = new ChatNode();
        saleNode.text = "Did you forget my Diet Dr. Kelp?";
        //call Andrews completeObjective function
        return saleNode;
    }

	
	private ChatNode GetExitNode()
	{
   	 ChatNode exitNode = new ChatNode();
   	 exitNode.text = "Keep the change you filthy animal!";
   	 return exitNode;
	}
   
   private void ExitDialogue()
   {
    	// Deactivate the dialogue UI GameObject
    //	GameObject.SetActive(false);
   }
   
}
