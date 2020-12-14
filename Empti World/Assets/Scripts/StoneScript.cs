 using System.Collections;
using System.Collections.Generic;
 using Unity.Mathematics;
 using UnityEngine;
 using Random = UnityEngine.Random;

 public class StoneScript : MonoBehaviour
{
    public float miningTime;
    private float currentMiningTime;
    public GameObject Stone;
    public int amount_spawned = 1;
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
            player.loadingBar.value = (miningTime - currentMiningTime) / miningTime;
            if (currentMiningTime <= 0)
            {
                player.loadingBar.gameObject.SetActive(false);
                currentMiningTime = miningTime;
                beingMined = false;
                player.blocked = false;
                player = null;
                Instantiate(Stone, gameObject.transform.position, Quaternion.identity);
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
