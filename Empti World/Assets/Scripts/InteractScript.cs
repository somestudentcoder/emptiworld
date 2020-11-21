using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private SpriteRenderer jeff;
    private int currentSprite = 0;
    public Sprite[] spriteArray;


    // Start is called before the first frame update
    void Start()
    {
        jeff = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeColor()
    {
        if(currentSprite == 1)
        {
            jeff.sprite = spriteArray[currentSprite-1];
        }
        else
        {
            jeff.sprite = spriteArray[currentSprite+1];
        }
    }
}
