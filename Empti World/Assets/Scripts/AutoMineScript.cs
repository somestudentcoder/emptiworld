using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMineScript : MonoBehaviour
{
    public GameObject rock;

    public float miningFrequency = 10;

    private float currentMiningTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMiningTime -= Time.deltaTime;

        if (currentMiningTime <= 0)
        {
            currentMiningTime = miningFrequency;
            Instantiate(rock, transform.position, Quaternion.identity);
        }
    }
}
