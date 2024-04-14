using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;





/*****************************************************************************
 *ChatSys: Contains the graph, and parsing functions
 * -  nodes are hardcoded, im sorry...
 * - attaches to the ChatUI
 * - monobehaviour
 *  
 *
 *****************************************************************************/
public class ChatSys : MonoBehaviour
{




    //dialogue vars
    public Text chatText;
    public Button[] optionButtons;

    //got rid of the serialized dynamic tree, just using static nodes for my sanity :0)
    private ChatNode currentNode;
    private ChatNode initNode;
    private ChatNode aboutNode;
    private ChatNode saleNode;
    private ChatNode exitNode;

    private ChatNode compNode; //compliment node

    private ChatNode PBNode; //Porta-bella's flirty dialogue node

    private GameObject panel;


    // Start is called before the first frame update
    // class wont stay monobehaviour, need to change this to spawn a prefab, assign references, then activate them in the current scene.
    void Start()
    {

        //Need reference to panel 
        panel = GameObject.Find("ChatUI");

        //reference UI's text
        chatText = GameObject.Find("Prompt").GetComponent<Text>();

        //made a mistake here, but dont want to go back and fix the skipped button
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
        //disable the panel
        panel.SetActive(false);

    }





    /*dialogue functions*/

    public void StartDialogue()
    {
        //enable the UI
        panel.SetActive(true);

        Time.timeScale = 0f; // Freeze time

        // Initialize the dialogue by showing the first node
        currentNode = GetInitialNode();
        UpdateUI();
    }

    private void UpdateUI()
    {
        chatText.text = currentNode.text; // Attempt to update text

        if (chatText.text == "Did you forget my drink?")
        {
            FindObjectOfType<Player>().DeliverPizza();
        }

        // Update the response buttons
        for (int i = 1; i < optionButtons.Length; i++)
        {
            if (i <= currentNode.responses.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = currentNode.responses[i - 1].text;

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
            currentNode = currentNode.responses[index - 1].nextNode;


            UpdateUI();
        }

        //exit the system, if goodbye node is chosen DOESNT WORK, CHANGE
        if (currentNode.text == "Keep the change you filthy animal!")
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
        if (aboutNode == null)
        {
            // Hard coded node for about the npc
            // For simplicity, return a hardcoded node,  will serialize or use setter function
            aboutNode = new ChatNode();
            aboutNode.text = "Nun-ya";
            aboutNode.responses.Add(new Response("Nice to meet you Nun-ya.", GetInitialNode()));
            aboutNode.responses.Add(new Response("That's nice! Take your stupid pizza.", GetSaleNode()));
            aboutNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option
        }
        return aboutNode;
    }


    //Will add to merchant (NPC child) once parent class is working
    //Need to add LastNode to finish conversations

    private ChatNode GetSaleNode()
    {
        if (saleNode == null)
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
        if (exitNode == null)
        {
            exitNode = new ChatNode();
            exitNode.text = "Keep the change you filthy animal!";
            exitNode.responses.Add(new Response("[Leave]", GetExitNode()));
            exitNode.responses.Add(new Response("[Leave]", GetExitNode()));
            exitNode.responses.Add(new Response("[Leave]", GetExitNode()));
        }
        return exitNode;
    }


    private ChatNode GetComplimentNode()
    {
        if (compNode == null)
        {
            // Hard coded transaction node
            // For simplicity, return a hardcoded node,  will serialize or use setter function
            compNode = new ChatNode();



            compNode.text = "Cheers Ladie!";


            compNode.responses.Add(new Response("Yes I did, can we start over?", GetInitialNode()));
            compNode.responses.Add(new Response("Tell me about yourself", GetAboutNode()));
            compNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option

            //call Andrews completeObjective function
        }
        return compNode;

    }



    private ChatNode GetPBNode()
    {
        if (PBNode == null)
        {
            // Hard coded transaction node
            // For simplicity, return a hardcoded node,  will serialize or use setter function
            PBNode = new ChatNode();
            PBNode.text = "Did you forget my drink?";
            PBNode.responses.Add(new Response("Yes I did, can we start over?", GetInitialNode()));
            PBNode.responses.Add(new Response("Tell me about yourself", GetAboutNode()));
            PBNode.responses.Add(new Response("Goodbye", GetExitNode())); // Add exit option

            //call Andrews completeObjective function
        }
        return PBNode;

    }

    private void ExitDialogue()
    {
        // Deactivate the dialogue UI GameObject
        panel.SetActive(false);
        Time.timeScale = 1f; // Freeze time
                             //destroy chatnode obj's here
    }


    private void UpdateExistingResponseText(int responseIndex, string newText)
    {
        if (responseIndex > 0 && responseIndex <= currentNode.responses.Count)
        {
            currentNode.responses[responseIndex - 1].UpdateText(newText);
        }
    }

}
