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
        PlayerScript player = GameObject.Find("Player").GetComponent<PlayerScript>();
        SoundEffectsHelperScript.Instance.playDoorSound();

        if(player.inhouse)
        {
            player.inhouse = false;
            player.blocked = false;
            player.heatDamageProne = true;
            player.coldDamageProne = true;
            GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            player.inhouse = true;
            player.blocked = true;
            player.heatDamageProne = false;
            if(GameObject.Find("Player").GetComponent<InventoryScript>().heater_built){
                if( GameObject.Find("SteamHeater(Clone)").GetComponent<FuelScript>().currentFuelTime > 0){
                    player.coldDamageProne = false;
                }
            }
            GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
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
