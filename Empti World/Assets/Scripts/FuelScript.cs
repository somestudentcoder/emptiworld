using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    public int fuelDuration = 30;
    public int maxFuelDuration = 300;

    private Slider fuelBar;
    private GameObject refuelMenu;

    public float currentFuelTime;

    private PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();

        
        refuelMenu = GameObject.Find("Player").GetComponent<InventoryScript>().refuelMenu;
        refuelMenu.SetActive(true);
        fuelBar = GameObject.Find("Fuel Bar").GetComponent<Slider>();
        fuelBar.maxValue = maxFuelDuration;
        refuelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") || Input.GetKeyDown(KeyCode.Escape)){
            refuelMenu.SetActive(false);
            player.busy = false;
        }

        if(currentFuelTime >= 0){
            currentFuelTime -= Time.deltaTime;
        }
        
        if(refuelMenu.activeSelf){
            //Debug.Log("Now");
            fuelBar = GameObject.Find("Fuel Bar").GetComponent<Slider>();
            fuelBar.value = currentFuelTime;
        }   
    }

    public void interact()
    {
        refuelMenu.SetActive(true);
    }

    
}
