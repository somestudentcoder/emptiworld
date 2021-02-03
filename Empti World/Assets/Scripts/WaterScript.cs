using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

    private PlayerScript player;
    private InventoryScript inventory;

    public float fillingTime;
    private float currentFillingTime;
    private bool filling = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        inventory = GameObject.Find("Player").GetComponent<InventoryScript>();
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
                inventory.water += 1;
                inventory.bucket -= 1;
            }
        }
    }


    public void interact(PlayerScript ply)
    {
        player = ply;
        filling = true;
        player.blocked = true;
    }
}
