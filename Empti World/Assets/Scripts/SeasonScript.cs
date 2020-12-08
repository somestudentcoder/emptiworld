using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SeasonScript : MonoBehaviour
{
    private Tilemap tilemap;
    public float SeasonCooldown;
    private float[] SeasonTimers;
    public int currentSeason;

    // Start is called before the first frame update
    void Start()
    {
        SeasonTimers = new float[4];
        setTimers();

        GameObject go = GameObject.Find("Grass");
        tilemap = go.GetComponentInChildren<Tilemap>();
        tilemap.RefreshAllTiles();
    }

    void setTimers()
    {
        for(int i = 0; i < SeasonTimers.Length; i++)
        {
            SeasonTimers[i] = SeasonCooldown;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SeasonTimers[currentSeason] -= Time.deltaTime;
        if(SeasonTimers[currentSeason] <= 0)
        {
            nextSeason();
        }
    }

    void nextSeason()
    {
        Debug.Log("Changing Seasons..");
        currentSeason++;
        if(currentSeason > 3)
        {
            currentSeason = 0;
            setTimers();
        }
        changeTiles();
        changeTrees();
        changeMusic();
    }

    void changeTiles()
    {
        tilemap.RefreshAllTiles();
    }

    void changeTrees()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        foreach(GameObject tree in trees)
        {
            tree.GetComponent<TreeScript>().seasonChange();
        }
    }

    void changeMusic()
    {
        //TODO
    }
}
