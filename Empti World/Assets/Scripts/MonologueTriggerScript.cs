using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTriggerScript : MonoBehaviour
{
	public Content content;
	private MonologueManagerScript manager;

	void Start()
	{
		manager = GetComponent<MonologueManagerScript>();
		manager.StartMonologue(content);
	}

	void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Space))
    	{
    		NextMonologue();
    	}
    }

	public void NextMonologue()
	{
		manager.DisplayNextSentence();
	}
}
