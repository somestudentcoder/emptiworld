using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    //private int currentSprite = 0;
    //public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void interact()
    {
        GameObject player = GameObject.Find("Player");

        if(player.GetComponent<PlayerScript>().blocked)
        {
            player.GetComponent<PlayerScript>().blocked = false;
            player.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            player.GetComponent<PlayerScript>().blocked = true;
            player.GetComponent<SpriteRenderer>().enabled = false;
        }
        //TODO change house lightning when sprites are done
        /*
        if(currentSprite == 1)
        {
            currentSprite -= 1;
            spriteRenderer.sprite = spriteArray[currentSprite];
        }
        else
        {
            currentSprite += 1;
            spriteRenderer.sprite = spriteArray[currentSprite];
        }
        */
    }
}
