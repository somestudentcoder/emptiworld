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
            Instantiate(log, transform.position + new Vector3(0.0f + Random.Range(-0.7f, 0.7f), -3.5f + Random.Range(-0.1f, 0.1f), -1.0f), Quaternion.identity);
        }
    }
}
