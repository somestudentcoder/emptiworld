using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private GameObject player;

    public double pick_up_range = 3;

    public float smooth_time = 0.3f;

    public string resource_name;
    
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is in range, then move to player
        if (pick_up_range > (player.transform.position - gameObject.transform.position).magnitude)
        {
            Debug.Log("Moving to player");
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, player.transform.position , ref velocity, smooth_time);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //TODO: add the resource to the player
        Destroy(gameObject);
    }
}
