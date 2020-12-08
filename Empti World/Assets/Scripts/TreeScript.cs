using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public float fellingTime;
    private float currentFellingTime;

    public float regrowTime;
    private float currentRegrowTime;

    private bool beingFelled = false;
    private bool regrowing = false;

    //Sprite stuff
    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        currentFellingTime = fellingTime;
        currentRegrowTime = regrowTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingFelled)
        {
            currentFellingTime -= Time.deltaTime;
            if(currentFellingTime <= 0)
            {
                fellTree();
                currentFellingTime = fellingTime;
            }
        }
        if(regrowing)
        {
            currentRegrowTime -= Time.deltaTime;
            if(currentRegrowTime <= 0)
            {
                regrowTree();
                currentRegrowTime = regrowTime;
            }
        }
    }

    public void seasonChange()
    {
        spriteRenderer.sprite = spriteArray[GameObject.Find("GameManager").GetComponentInChildren<SeasonScript>().currentSeason];
    }

    private void fellTree()
    {
        spriteRenderer.sprite = spriteArray[4];
        player.blocked = false;
        player = null;
        beingFelled = false;
        regrowing = true;
    }

    private void regrowTree()
    {
        spriteRenderer.sprite = spriteArray[GameObject.Find("GameManager").GetComponentInChildren<SeasonScript>().currentSeason];
        regrowing = false;
    }

    public void interact(PlayerScript ply)
    {
        if(regrowing)
        {
            return;
        }
        player = ply;
        player.blocked = true;
        beingFelled = true;
    }
}
