using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSawmillScript : MonoBehaviour
{
    public GameObject log;

    public float fellingFrequency = 10;

    private float currentFellingTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentFellingTime -= Time.deltaTime;

        if (currentFellingTime <= 0)
        {
            currentFellingTime = fellingFrequency;
            Instantiate(log, transform.position, Quaternion.identity);
        }
    }
}
