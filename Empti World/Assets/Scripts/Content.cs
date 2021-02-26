using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Content
{
	[TextArea(2,10)]
	public string[] content;
	public Sprite[] headshot;
}