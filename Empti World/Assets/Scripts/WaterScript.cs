using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

    private PlayerScript player;

    public float fillingTime;
    private float currentFillingTime;
    private bool filling = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (filling)
        {
            currentFillingTime -= Time.deltaTime;
            player.loadingBar.value = (fillingTime - currentFillingTime) / fillingTime;
            if (currentFillingTime <= 0)
            {
                player.loadingBar.gameObject.SetActive(false);
                currentFillingTime = fillingTime;
                filling = false;
                player.blocked = false;
                player = null;


            }
        }
        else if (PlayerIsInteracting())
        {
            interact();
            
        }
    }

    public bool PlayerIsInteracting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider.transform == this.transform)
            {
                // raycast hit this gameobject
                Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(mouse_position, player.transform.position);
                if (distance <= 3)
                {
                    Debug.Log("hit a water tile");
                    return true;
                }
            }
        }
        return false;
    }

    public void interact()
    {
        player.loadingBar.gameObject.SetActive(true);
        Camera cam = Camera.main.GetComponent<Camera>();
        Vector3 screenPos = cam.WorldToScreenPoint(player.transform.position);
        player.loadingBar.transform.position = screenPos + new Vector3(0, 60, 0);
        filling = true;
        player.blocked = true;
    }
}
