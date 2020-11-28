 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public float miningTime;
    private float currentMiningTime;

    private bool beingMined = false;

    private PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        currentMiningTime = miningTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingMined)
        {
            currentMiningTime -= Time.deltaTime;
            if(currentMiningTime <= 0)
            {
                currentMiningTime = miningTime;
                beingMined = false;
                player.blocked = false;
                player = null;
            }
        }
    }

    public void interact(PlayerScript ply)
    {
        player = ply;
        player.blocked = true;
        beingMined = true;
    }
}
