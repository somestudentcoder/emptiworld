using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopScript : MonoBehaviour
{
    public AudioSource[] seasonMusic;

    private AudioSource activePlayer;

    // Start is called before the first frame update
    void Start()
    {
        activePlayer = seasonMusic[0];
        activePlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // nothing
    }

    internal void seasonChange()
    {
        int season = GameObject.Find("GameManager").GetComponentInChildren<SeasonScript>().currentSeason;
        season = season % 4;
        activePlayer.Stop();
        activePlayer = seasonMusic[season];
        activePlayer.Play();
    }

    internal void changeMusic()
    {

    }
}
