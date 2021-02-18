using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class SpriteList
{
    public Sprite[] sprites;
}

public class FarmingFieldScript : MonoBehaviour
{
	const int EMPTY = 0;
	const int GROWING = 1;
	const int DONE = 2;

	public GameObject cropPickUp;
	public GameObject crop;
	private GameObject cropInstance;

    public float actionTime;
    private float currentActionTime;

    public float growTime;
    private float currentGrowTime;

    private bool planting = false;
    private bool growing = false;
    private bool done = false;
    private bool harvesting = false;

    //Sprite stuff
    private SpriteRenderer spriteRenderer;
    public SpriteList[] spriteArray;
    private int spriteAmount;
    private int currentSprite;

    private PlayerScript player;
    private SeasonScript seasonScript;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        currentActionTime = actionTime;
        currentGrowTime = growTime;
        spriteAmount = spriteArray[0].sprites.Length - 1;
        seasonScript = GameObject.Find("GameManager").GetComponent<SeasonScript>();
        currentSprite = EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
    	if(planting)
    	{
    		currentActionTime -= Time.deltaTime;
    		player.loadingBar.value = (actionTime - currentActionTime) / actionTime;
    		if (currentActionTime <= 0)
            {
                player.loadingBar.gameObject.SetActive(false);
                player.busy = false;
                currentActionTime = actionTime;
                player.blocked = false;
                player = null;
                planting = false;
                growing = true;
                changeSprite();
                createCrop();
            }
    	}
    	else if(growing)
    	{
    		currentGrowTime -= Time.deltaTime;
            if(currentGrowTime <= 0)
            {
                currentGrowTime = growTime;
                growing = false;
                done = true;
                //changeSprite();
                changeCropSprite();
            }
    	}
    	else if(harvesting)
    	{
    		currentActionTime -= Time.deltaTime;
    		player.loadingBar.value = (actionTime - currentActionTime) / actionTime;
    		if (currentActionTime <= 0)
            {
            	//DROPS WHEAT
            	Instantiate(cropPickUp, transform.position, Quaternion.identity);
                player.loadingBar.gameObject.SetActive(false);
                currentActionTime = actionTime;
                done = false;
                changeSprite();
	            player.blocked = false;
	            player = null;
	            harvesting = false;
	            Destroy(cropInstance);
            }
    	}
    }

    void changeCropSprite()
    {
	    cropInstance.GetComponent<CropScript>().grow();
    }
    
    void createCrop()
    {
	    cropInstance = Instantiate(crop, transform.position + Vector3.up * 0.5f, Quaternion.identity);
    }
    
    public void seasonChange()
    {
        //Debug.Log(seasonScript.currentSeason);
        spriteRenderer.sprite = spriteArray[seasonScript.currentSeason].sprites[currentSprite];
    }

    private void changeSprite()
    {
    	Debug.Log("growing:" + growing);
    	Debug.Log("done:" + done);
    	Debug.Log("harvesting:" + harvesting);
    	Debug.Log("planting:" + planting);
    	if(growing)
    	{
    		spriteRenderer.sprite = spriteArray[seasonScript.currentSeason].sprites[GROWING];
    		currentSprite = GROWING;
    	}
    	else if(done)
    	{
    		spriteRenderer.sprite = spriteArray[seasonScript.currentSeason].sprites[DONE];
    		currentSprite = DONE;
    	}
    	else if(harvesting)
    	{
    		spriteRenderer.sprite = spriteArray[seasonScript.currentSeason].sprites[EMPTY];
    		currentSprite = EMPTY;
    	}
    }

    public void interact(PlayerScript ply)
    {
    	if(!done && !growing)
    	{
    		player = ply;
    		player.blocked = true;
    		planting = true;
    	}
    	else if(done)
    	{
    		player = ply;
    		player.blocked = true;
    		harvesting = true;
    	}
    }
}
