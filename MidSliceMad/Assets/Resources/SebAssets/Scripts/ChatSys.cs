using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

//have option argument for startdialogue to determine which dialogue 

public class ChatSys : MonoBehaviour
{


    //dialogue vars
    public Text chatText;
    public Button[] optionButtons;

    //got rid of graph structure
    private ChatNode currentNode;
    private ChatNode initNode;
    private ChatNode aboutNode;
    private ChatNode saleNode;
    private ChatNode exitNode;

    private GameObject datChat;
   
    
 // Start is called before the first frame update
    // class wont stay monobehaviour, need to change this to spawn a prefab, assign references, then activate them in the current scene.
    void Start()
    {

         //Need reference to panel & chatUI to activate them
        datChat = GameObject.Find("ChatUI");
      //Need reference to panel & canvas to activate them
    	// Find and assign references to UI elements using GetComponent
    	
        chatText = GameObject.Find("Prompt").GetComponent<Text>(); 
        optionButtons = new Button[5]; // Assuming you have 4 response option buttons

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
        datChat.SetActive(false);
        
  		//StartDialogue();
    }


	
        public ChatSys(GameObject chatUI) 
        {
            this.datChat = chatUI; //call function
            // Find and assign references to UI elements using GetComponent
    	
            chatText = GameObject.Find("Prompt").GetComponent<Text>(); 
            optionButtons = new Button[5]; // Assuming you have 4 response option buttons

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
        
            datChat.SetActive(false);
        }

	
	/*dialogue functions*/
	
	public void StartDialogue()
    {
         datChat.SetActive(true);
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
            if (i <= currentNode.responses.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = currentNode.responses[i-1].text;


                
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


        if (index <= currentNode.responses.Count)
        {
            // Update the current node based on the chosen response
            currentNode = currentNode.responses[index-1].nextNode;
            

            UpdateUI();
        }
        
        //exit the system, if goodbye node is chosen DOESNT WORK, CHANGE
        if(currentNode.text == "Keep the change you filthy animal!")
        {
        	ExitDialogue();
        }
    }

    private ChatNode GetInitialNode()
    {
    	if (initNode == null)
    	{
        	// Hard coded introduction node
        	// For simplicity, return a hardcoded node,  will serialize or use setter function
        	initNode = new ChatNode();
        	initNode.text = "Do you have my Pizza.";
        	initNode.responses.Add(new Response("Tell me about yourself", GetAboutNode()));
        	initNode.responses.Add(new Response("Heres your Pizza", GetSaleNode()));
        	initNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option
        }
        return initNode;
    }


    private ChatNode GetAboutNode()
    {
    	if(aboutNode == null)
    	{
        	// Hard coded node for about the npc
        	// For simplicity, return a hardcoded node,  will serialize or use setter function
        	aboutNode = new ChatNode();
        	aboutNode.text = "Nun-ya";
        	aboutNode.responses.Add(new Response("Nice to meet you Nun-ya.", GetInitialNode()));
        	aboutNode.responses.Add(new Response("What do you have for sale?", GetSaleNode()));
        	aboutNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option
        }
        return aboutNode;
    }


//Will add to merchant (NPC child) once parent class is working
//Need to add LastNode to finish conversations

    private ChatNode GetSaleNode()
    {
    	if(saleNode == null)
    	{
        	// Hard coded transaction node
        	// For simplicity, return a hardcoded node,  will serialize or use setter function
        	saleNode = new ChatNode();
        	saleNode.text = "Did you forget my drink?";
        	saleNode.responses.Add(new Response("Yes I did, can we start over?", GetInitialNode()));
        	saleNode.responses.Add(new Response("Tell me about yourself", GetAboutNode()));
        	saleNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option

        	//call Andrews completeObjective function
        }
        return saleNode;
        
    }

	
	private ChatNode GetExitNode()
	{
		if(exitNode == null)
		{
   	 		exitNode = new ChatNode();
   		 	exitNode.text = "Keep the change you filthy animal!";
            exitNode.responses.Add(new Response("[Leave]", GetExitNode()));
        	exitNode.responses.Add(new Response("[Leave]", GetExitNode()));
        	exitNode.responses.Add(new Response("[Leave]", GetExitNode()));
   	 	}
   	 	return exitNode;
	}
   

   private void ExitDialogue()
   {
    	// Deactivate the dialogue UI GameObject
        datChat.SetActive(false);
   }


   private void UpdateExistingResponseText(int responseIndex, string newText)
{
    if (responseIndex > 0 && responseIndex <= currentNode.responses.Count)
    {
        currentNode.responses[responseIndex - 1].UpdateText(newText);
    }
}
   
}
