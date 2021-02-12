using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SeasonScript : MonoBehaviour
{
    private ArrayList tilemaps = new ArrayList();
    public float SeasonCooldown;
    public float StormCooldown;
    private bool stormActive = false;
    private float StormTimer;
    private float[] SeasonTimers;
    public int currentSeason;
    public GameObject snow;
    public GameObject sand;
    private GameObject player;
    private GameObject stormindicator;

    // Start is called before the first frame update
    void Start()
    {
        SeasonTimers = new float[4];
        setTimers();

        player = GameObject.Find("Player");
        stormindicator = GameObject.Find("Storm Activity Indicator");
        stormindicator.SetActive(false);

        GameObject grass_tilemap = GameObject.Find("Grass");
        GameObject ground_tilemap = GameObject.Find("Ground");
        GameObject water_tilemap = GameObject.Find("Water");
        tilemaps.Add(grass_tilemap.GetComponentInChildren<Tilemap>());
        tilemaps.Add(ground_tilemap.GetComponentInChildren<Tilemap>());
        tilemaps.Add(water_tilemap.GetComponentInChildren<Tilemap>());
        refreshAllTileMaps();
    }

    void refreshAllTileMaps()
    {
        foreach (Tilemap map in tilemaps)
        {
            map.RefreshAllTiles();
        }
    }

    void setTimers()
    {
        for(int i = 0; i < SeasonTimers.Length; i++)
        {
            SeasonTimers[i] = SeasonCooldown;
        }
        StormTimer = StormCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        //Season timer
        SeasonTimers[currentSeason] -= Time.deltaTime;
        //Storm timer
        if(stormActive)
        {
            StormTimer -= Time.deltaTime;
            if(StormTimer <= 0)
            {
                StormTimer = StormCooldown;
                byeStorm();
            }
            else if(player.GetComponent<PlayerScript>().damageable)
            {
                if(currentSeason == 1 && player.GetComponent<PlayerScript>().heatDamageProne)
                {
                    player.GetComponent<PlayerScript>().damage(20);
                }
                else if(currentSeason == 3 && player.GetComponent<PlayerScript>().coldDamageProne)
                {
                    player.GetComponent<PlayerScript>().damage(20);
                }
            }
        }
        //Season change or Storm trigger
        if(SeasonTimers[currentSeason] <= 0)
        {
            nextSeason();
        }
        else if((SeasonTimers[currentSeason] < (SeasonCooldown / 2.0f) + StormCooldown/2.0f) 
            && (SeasonTimers[currentSeason] > (SeasonCooldown / 2.0f) - StormCooldown/2.0f) && (currentSeason == 1 || currentSeason == 3))
        {
            triggerStorm();
        }
    }

    void nextSeason()
    {
        currentSeason++;
        
        if(currentSeason > 3)
        {
            currentSeason = 0;
            setTimers();
        }
        changeTiles();
        changeTrees();
        changeFarmingFields();
        changeMusic();
    }

    void triggerStorm()
    {
        if (currentSeason == 3)
        {
            snow.SetActive(true);
        }
        else
        {
            sand.SetActive(true);
        }
        stormActive = true;
        visualStorm(stormActive);
        audibleStorm(stormActive);
    }

    void byeStorm()
    {
        snow.SetActive(false);
        sand.SetActive(false);
        stormActive = false;
        visualStorm(stormActive);
        audibleStorm(stormActive);
    }

    void visualStorm(bool active)
    {
        stormindicator.SetActive(active);
    }

    void audibleStorm(bool active)
    {
        if(active)
        {

        }
        else
        {

        }
    }

    void changeTiles()
    {
        refreshAllTileMaps();
    }

    void changeTrees()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        foreach(GameObject tree in trees)
        {
            tree.GetComponent<TreeScript>().seasonChange();
        }
    }

    void changeFarmingFields()
    {
        GameObject[] fields = GameObject.FindGameObjectsWithTag("FarmingField");
        foreach(GameObject field in fields)
        {
            field.GetComponent<FarmingFieldScript>().seasonChange();
        }
    }

    void changeMusic()
    {
        GameObject.Find("MusicLoop").GetComponent<MusicLoopScript>().seasonChange();
    }
}
