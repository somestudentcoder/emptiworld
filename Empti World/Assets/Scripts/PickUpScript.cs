using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private GameObject player;

    public double pick_up_range = 3;

    public float smooth_time = 0.3f;

    public string resource_name;

    public int amount = 1;
    public float initial_travel_time = 0.3f;

    private bool initial_movement_done = false;
    private InventoryScript inventory;
    private Vector3 offset;
    private Vector3 initial_position;
    private float start_time;
    
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        player = GameObject.FindWithTag("Player");
        inventory = GameObject.Find("Player").GetComponent<InventoryScript>();
        offset = Random.insideUnitCircle.normalized * 2.0f;
        
        initial_position = transform.position;
        offset += initial_position;
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!initial_movement_done)
        {
            initialMovement();
        }
        // Check if player is in range, then move to player
        else if (pick_up_range > (player.transform.position - gameObject.transform.position).magnitude)
        {
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, player.transform.position , ref velocity, smooth_time);
        }
    }

    void initialMovement()
    {
        // The center of the arc
        Vector3 center = (initial_position + offset) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, 1, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = initial_position- center;
        Vector3 setRelCenter = offset - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - start_time) / initial_travel_time;

        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
        if (transform.position == offset)
        {
            initial_movement_done = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (initial_movement_done && col.gameObject.tag == "Player")
        {
            inventory.addResource(resource_name, amount);
            Destroy(gameObject);
        }
    }
}
