using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SeasonScript : MonoBehaviour
{
    private ArrayList tilemaps = new ArrayList();
    public float SeasonCooldown;
    private float[] SeasonTimers;
    public int currentSeason;

    // Start is called before the first frame update
    void Start()
    {
        SeasonTimers = new float[4];
        setTimers();

        GameObject grass_tilemap = GameObject.Find("Grass");
        GameObject ground_tilemap = GameObject.Find("Ground");
        GameObject impassable_tilemap = GameObject.Find("Impassable");
        tilemaps.Add(grass_tilemap.GetComponentInChildren<Tilemap>());
        tilemaps.Add(ground_tilemap.GetComponentInChildren<Tilemap>());
        tilemaps.Add(impassable_tilemap.GetComponentInChildren<Tilemap>());
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
        changeFarmingFields();
        changeMusic();
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
