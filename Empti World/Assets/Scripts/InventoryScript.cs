using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    private bool showInventory = false;
    private GameObject inventory;

    // Text fields to display resource numbers
    private Text cable_resource_text;
    private Text microchip_resource_text;
    private Text stone_resource_text;
    private Text iron_resource_text;
    private Text coal_resource_text;
    private Text wood_resource_text;
    private Text water_resource_text;
    private Text crop_resource_text;


    // All resources a player can have
    // Basic resources
    public int cable = 0;
    public int microchip = 0;
    public int stone = 0;
    public int iron = 0;
    public int coal = 0;
    public int wood = 0;
    public int water = 0;
    public int crop = 0;

    // Common resources
    public int oven = 0;
    public int bucket = 0;

    // Technology resources

    // Construction resources
    public int steam_engine = 0;
    public int brass_pipe = 0;

    // Alchemy resources


    // Start is called before the first frame update
    void Start()
    {
        // Set all text fields
        cable_resource_text = GameObject.Find("Cable Resource Text").GetComponent<Text>();
        microchip_resource_text = GameObject.Find("Microchip Resource Text").GetComponent<Text>();
        stone_resource_text = GameObject.Find("Stone Resource Text").GetComponent<Text>();
        iron_resource_text = GameObject.Find("Iron Resource Text").GetComponent<Text>();
        coal_resource_text = GameObject.Find("Coal Resource Text").GetComponent<Text>();
        wood_resource_text = GameObject.Find("Wood Resource Text").GetComponent<Text>();
        water_resource_text = GameObject.Find("Water Resource Text").GetComponent<Text>();
        crop_resource_text = GameObject.Find("Crop Resource Text").GetComponent<Text>();

        /*microchip_resource_text;
        stone_resource_text;
        iron_resource_text;
        coal_resource_text;
        wood_resource_text;
        water_resource_text;
        crop_resource_text;*/

        inventory = GameObject.Find("Inventory");
        inventory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cable_resource_text.text = "x" + cable;
        microchip_resource_text.text = "x" + microchip;
        stone_resource_text.text = "x" + stone;
        iron_resource_text.text = "x" + iron;
        coal_resource_text.text = "x" + coal;
        wood_resource_text.text = "x" + wood;
        water_resource_text.text = "x" + water;
        crop_resource_text.text = "x" + crop;

        // Open/Close Inventory
        if (Input.GetKeyDown("e"))
        {
            showInventory = !showInventory;
            inventory.gameObject.SetActive(showInventory);
        }
    }

    public void craftOven()
    {
        // Required resources
        const int required_stone = 8;

        // Continue only if all requirements are met
        if(stone >= required_stone)
        {
            stone -= required_stone;
            oven += 1;
        }
    }

    public void craftBucket()
    {
        // Required resources
        const int required_iron = 4;

        // Continue only if all requirements are met
        if (iron >= required_iron)
        {
            iron -= required_iron;
            bucket += 1;
        }
    }

    public void craftGarden()
    {
        // Required resources
        const int required_water = 4;
        const int required_wood = 4;

        // Continue only if all requirements are met
        if (water >= required_water && wood >= required_wood)
        {
            wood -= required_wood;
            water -= required_water;
            //TODO upgrade garden
        }
    }

    public void craftBasicHouse()
    {
        // Required resources
        const int required_iron = 4;
        const int required_stone = 8;
        const int required_wood = 16;

        // Continue only if all requirements are met
        if (iron >= required_iron && stone >= required_stone && wood >= required_wood)
        {
            
            iron -= required_iron;
            stone -= required_stone;
            wood -= required_wood;
            //TODO upgrade house
        }
    }
}
