using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
	public TextMeshProUGUI chat;
	public string[] lines;
	public float textSpeed;
	
	private int index = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        chat.text = string.Empty;
		StartDialogue();
		
    }

    // Update is called once per frame
    void Update()
    {
		//check for mouse click, if click, skip Typeline & instantly print message
        if(Input.GetMouseButtonDown(0))
		{
			if(chat.text == lines[index])
			{
				NextLine();
			}
			else
			{
				StopAllCoroutines();
				chat.text = lines[index];
			}
		}
    }
	
	void StartDialogue()
	{
		
		
		index = 0;
		StartCoroutine(TypeLine());
	}
	
	//prints the message char by char
	IEnumerator TypeLine()
	{
		foreach(char c in lines[index].ToCharArray())
		{
			chat.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
	}
	
	void NextLine()
	{
		if(index < lines.Length -1)
		{
			index++;
			chat.text = string.Empty;
			StartCoroutine(TypeLine());
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
