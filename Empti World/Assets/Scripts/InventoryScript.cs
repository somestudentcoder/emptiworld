using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    private bool showInventory = false;
    private GameObject inventoryUI;

    // Text fields to display resource numbers
    private Text cable_resource_text;
    private Text microchip_resource_text;
    private Text stone_resource_text;
    private Text iron_resource_text;
    private Text coal_resource_text;
    private Text wood_resource_text;
    private Text water_resource_text;
    private Text crop_resource_text;

    public GameObject house;
    public GameObject oven;
    public GameObject garden;
    public GameObject mine;
    public GameObject sawmill;

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

        inventoryUI = GameObject.Find("Inventory");
        inventoryUI.gameObject.SetActive(false);
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
            inventoryUI.gameObject.SetActive(showInventory);
        }
    }

    public void craftOven()
    {
        // Required resources
        const int required_stone = 8;

        // Continue only if all requirements are met
        if (stone >= required_stone)
        {
            stone -= required_stone;
            Instantiate(oven, new Vector3(0, 0, 0), Quaternion.identity);
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

            Instantiate(house, new Vector3(2, 5, 0), Quaternion.identity);
        }
    }

    public void craftMine()
    {
        // Required resources
        const int required_iron = 8;
        const int required_stone = 8;
        const int required_wood = 8;

        if (iron >= required_iron && stone >= required_stone && wood >= required_wood)
        {
            iron -= required_iron;
            stone -= required_stone;
            wood -= required_wood;

            Instantiate(mine, new Vector3(20, 27, 5), Quaternion.identity);
        }
    }

    public void craftSawmill()
    {
        // Required resources
        const int required_iron = 8;
        const int required_stone = 0;
        const int required_wood = 8;

        if (iron >= required_iron && stone >= required_stone && wood >= required_wood)
        {
            iron -= required_iron;
            stone -= required_stone;
            wood -= required_wood;

            Instantiate(sawmill, new Vector3(-44, 34, 0), Quaternion.identity);
        }
    }

    public void addResource(string resource_name, int amount)
    {
        switch (resource_name)
        {
            case "Wood":
                wood += amount;
                break;
            case "Stone":
                stone += amount;
                break;
            case "Coal":
                coal += amount;
                break;
            case "Iron":
                iron += amount;
                break;
            case "Water":
                water += amount;
                break;
            case "Crop":
                crop += amount;
                break;
            case "MicroChip":
                microchip += amount;
                break;
            case "Cable":
                cable += amount;
                break;
            default:
                Debug.Log("This resource is not known: " + resource_name);
                break;
        }
    }
}
