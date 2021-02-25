using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueManagerScript : MonoBehaviour
{
	private Queue<string> content = new Queue<string>();
	public bool active;
	public Text contentDisplay;
	public string currentContent;

    public void StartMonologue(Content monologue)
    {
    	active = true;
    	foreach(string sentence in monologue.content)
    	{
    		content.Enqueue(sentence);
    	}

    	DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
    	if(content.Count == 0)
    	{
    		if(GameObject.Find("ContinueText").GetComponent<Text>().text == "Space to continue")
    		{
    			GameObject.Find("ContinueText").GetComponent<Text>().text = "Space to end";
    		}
    		else
    		{
    			EndMonologue();
    		}
    	}
    	else
    	{
    		currentContent = content.Dequeue();
    		StopAllCoroutines();
    		StartCoroutine(TypingSentence());
    	}
    }

    public void RestartTyping()
    {
    	StopAllCoroutines();
        StartCoroutine(TypingSentence());
    }

    IEnumerator TypingSentence()
    {
    	contentDisplay.text = "";
    	foreach(char letter in currentContent.ToCharArray())
    	{
    		contentDisplay.text += letter;
    		yield return null;
    	}
    }

    public void EndMonologue()
    {	
    	active = false;
    	content.Clear();
    	GameObject.Find("Monologue").SetActive(false);
    }
}
