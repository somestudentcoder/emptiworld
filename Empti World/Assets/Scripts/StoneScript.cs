 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public GameObject rock;

    public float miningTime;
    
    private float currentMiningTime;

    private bool beingMined = false;

    public int specialMineralMax = 3;
    [HideInInspector]
    public int specialMineralCount = 0;
    [HideInInspector]
    public bool isSpecial = false;
    [HideInInspector]
    public string specialName = "";

    private PlayerScript player;

    private MaterialSpawningScript spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        currentMiningTime = miningTime;
        spawner = GameObject.Find("GameManager").GetComponent<MaterialSpawningScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beingMined)
        {
            currentMiningTime -= Time.deltaTime;
            player.loadingBar.value = (miningTime - currentMiningTime) / miningTime;
            if (currentMiningTime <= 0)
            {
                player.loadingBar.gameObject.SetActive(false);
                player.busy = false;
                currentMiningTime = miningTime;
                beingMined = false;
                player.blocked = false;
                player = null;
                Instantiate(rock, transform.position, Quaternion.identity);
                if (isSpecial)
                {
                    specialMineralCount++;
                    if (specialMineralCount >= specialMineralMax)
                    {
                        spawner.specialDepleted(gameObject, specialName);
                    }
                }
                //Instantiate(rock, transform.position + new Vector3(0.0f + Random.Range(-0.7f, 0.7f), -2.0f + Random.Range(-0.1f, 0.1f), -1.0f), Quaternion.identity);
            }
        }
    }

    public void interact(PlayerScript ply)
    {
        player = ply;
        player.blocked = true;
        beingMined = true;
        SoundEffectsHelperScript.Instance.playMiningSound();
    }
}
