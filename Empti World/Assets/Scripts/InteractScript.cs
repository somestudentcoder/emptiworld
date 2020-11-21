using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int currentSprite = 0;
    public Sprite[] spriteArray;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact()
    {
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
        if(player)
        {
            player.interactPossible = true;
            player.interactor = this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
        if(player)
        {
            player.interactPossible = false;
            player.interactor = null;
        }
    }
}
