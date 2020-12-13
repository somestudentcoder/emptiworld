using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteList
{
    public Sprite[] sprites;
}

public class FarmingFieldScript : MonoBehaviour
{
    public float farmingTime;
    private float currentFarmingTime;

    public float growTime;
    private float currentGrowTime;

    private bool beingFarmed = false;
    private bool farmed = false;
    private bool done = false;
    private bool harvest = false;

    //Sprite stuff
    private SpriteRenderer spriteRenderer;
    public SpriteList[] spriteArray;
    private int spriteAmount;
    private int currentSprite = 0;

    private PlayerScript player;
    private SeasonScript seasonScript;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        currentFarmingTime = farmingTime;
        currentGrowTime = growTime;
        spriteAmount = spriteArray[0].sprites.Length - 1;
        seasonScript = GameObject.Find("GameManager").GetComponent<SeasonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(beingFarmed)
        {
            currentFarmingTime -= Time.deltaTime;
            player.loadingBar.value = (farmingTime - currentFarmingTime) / farmingTime;
            if (currentFarmingTime <= 0)
            {
                player.loadingBar.gameObject.SetActive(false);
                currentFarmingTime = farmingTime;
                player.blocked = false;
                player = null;
                beingFarmed = false;
                farmed = true;
                changeSprite();
            }
        }
        else if(farmed)
        {
            currentGrowTime -= Time.deltaTime;
            if(currentGrowTime <= 0)
            {
                currentGrowTime = growTime;
                farmed = false;
                done = true;
                changeSprite();
            }
        }
        else if(harvest)
        {
            changeSprite();
            player.blocked = false;
            player = null;
            harvest = false;
        }
    }

    public void seasonChange()
    {
        Debug.Log(seasonScript.currentSeason);
        spriteRenderer.sprite = spriteArray[seasonScript.currentSeason].sprites[currentSprite];
    }

    private void changeSprite()
    {
        
        currentSprite++;
        if(currentSprite <= spriteAmount)
        {
            spriteRenderer.sprite = spriteArray[seasonScript.currentSeason].sprites[currentSprite];
        }
        else
        {
            currentSprite = 0;
            spriteRenderer.sprite = spriteArray[seasonScript.currentSeason].sprites[currentSprite];
        }
    }

    public void interact(PlayerScript ply)
    {
        if(farmed)
        {
            return;
        }
        player = ply;
        player.blocked = true;
        if(!done)
        {
            beingFarmed = true;   
        }
        else
        {
            harvest = true;
            done = false;
        }
    }
}
