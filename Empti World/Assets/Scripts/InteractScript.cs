using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    private PlayerScript player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if(PlayerIsInteracting()){
            interact(player);
        }
    }

    public bool PlayerIsInteracting()
    {
        if (Input.GetMouseButtonDown(0) && (!player.blocked || player.inhouse))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider.transform == this.transform)
            {
                // raycast hit this gameobject
                
                WaterScript water = GetComponent<WaterScript>();
                if(water != null){
                    // gameobject is water
                    Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float distance = Vector2.Distance(mouse_position, player.transform.position);
                    
                    
                    InventoryScript inventory = player.GetComponent<InventoryScript>();
                    if (distance <= 3 && inventory.bucket > 0)
                    {
                        return true;
                    }
                }
                else{
                    BoxCollider2D trigger_collider = null;
                    BoxCollider2D[] colliders = hit.collider.gameObject.GetComponents<BoxCollider2D>();
                    foreach (BoxCollider2D col in colliders){
                        if(col.isTrigger){
                            trigger_collider = col;
                            break;
                        }
                    }
                    if(trigger_collider == null){
                        return false;
                    }
                    Vector2 distance_vector = (Vector2)player.transform.position - ((Vector2)(gameObject.transform.position) + trigger_collider.offset);
                    float distance_x = Mathf.Abs(distance_vector.x) - (trigger_collider.size.x / 2);
                    float distance_y = Mathf.Abs(distance_vector.y) - (trigger_collider.size.y / 2);
                    if (distance_x <= 1.5 && distance_y <= 1.5)
                    {
                        return true;
                    }
                }
                
            }
        }
        return false;
    }


    public void interact(PlayerScript player)
    {
        player.busy = true;
        player.loadingBar.gameObject.SetActive(true);
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPos = cam.WorldToScreenPoint(player.transform.position);
        player.loadingBar.transform.position = screenPos + new Vector3(0, 60, 0);

        //find which object it is and interact with it
        if (GetComponent<TreeScript>())
        {
            GetComponent<TreeScript>().interact(player);
        }
        if (GetComponent<WaterScript>())
        {
            GetComponent<WaterScript>().interact(player);
        }
        else if(GetComponent<StoneScript>())
        {
            GetComponent<StoneScript>().interact(player);
        }
        else if(GetComponent<FarmingFieldScript>())
        {
            GetComponent<FarmingFieldScript>().interact(player);
        }
        else if(GetComponent<InteractableObjectScript>())
        {
            GetComponent<InteractableObjectScript>().interact();
        }
        else if (GetComponent<HouseScript>())
        {
            player.loadingBar.gameObject.SetActive(false);
            GetComponent<HouseScript>().interact();
            player.busy = false;
        }
        else if(GetComponent<FuelScript>())
        {
            player.loadingBar.gameObject.SetActive(false);
            GetComponent<FuelScript>().interact();
        }
    }
}
