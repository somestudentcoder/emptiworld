﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryScript : MonoBehaviour
{
    private bool showInventory = false;
    private GameObject inventoryUI;
    private GameObject minimap;
    private GameObject minimapBorder;


    public GameObject house;
    public GameObject oven;
    public GameObject garden;
    public GameObject mine;
    public GameObject sawmill;

    // Text fields to display resource numbers
    // Basic resources
    private Text stone_resource_text;
    private Text iron_ore_resource_text;
    private Text wood_resource_text;
    private Text water_resource_text;
    private Text crop_resource_text;

    // Common resources
    private Text coal_resource_text;
    private Text iron_ingot_resource_text;
    private Text bucket_resource_text;

    // Technology resources

    // Construction resources
    private Text tin_ore_resource_text;
    private Text copper_ore_resource_text;
    private Text tin_ingot_resource_text;
    private Text copper_ingot_resource_text;
    private Text brass_ingot_resource_text;
    private Text steam_engine_resource_text;
    private Text engine_fuel_resource_text;

    // Alchemy resources

    // Resource variables
    // Basic resources
    public int stone = 0;
    public int iron_ore = 0;
    public int wood = 0;
    public int water = 0;
    public int crop = 0;


    // Common resources
    public int coal = 0;
    public int iron_ingot = 0;
    public int bucket = 0;

    // Technology resources

    // Construction resources
    public int tin_ore = 0;
    public int copper_ore = 0;
    public int tin_ingot = 0;
    public int copper_ingot = 0;
    public int brass_ingot = 0;
    public int steam_engine = 0;
    public int engine_fuel = 0;

    // Alchemy resources

    // Upgrades
    public bool oven_upgrade = false;

    // Monologue
    private GameObject monologue;


    // Start is called before the first frame update
    void Start()
    {
        // Set all text fields
        // Basic resources 
        stone_resource_text = GameObject.Find("Stone Resource Text").GetComponent<Text>();
        iron_ore_resource_text = GameObject.Find("Iron Ore Resource Text").GetComponent<Text>();
        wood_resource_text = GameObject.Find("Wood Resource Text").GetComponent<Text>();
        water_resource_text = GameObject.Find("Water Resource Text").GetComponent<Text>();
        crop_resource_text = GameObject.Find("Crop Resource Text").GetComponent<Text>();

        //Common resources
        coal_resource_text = GameObject.Find("Coal Resource Text").GetComponent<Text>();
        iron_ingot_resource_text = GameObject.Find("Iron Ingot Resource Text").GetComponent<Text>();
        bucket_resource_text = GameObject.Find("Bucket Resource Text").GetComponent<Text>();

        // Technology resources

        // Construction resources
        tin_ore_resource_text = GameObject.Find("Tin Ore Resource Text").GetComponent<Text>();
        copper_ore_resource_text = GameObject.Find("Copper Ore Resource Text").GetComponent<Text>();
        tin_ingot_resource_text = GameObject.Find("Tin Ingot Resource Text").GetComponent<Text>();
        copper_ingot_resource_text = GameObject.Find("Copper Ingot Resource Text").GetComponent<Text>();
        brass_ingot_resource_text = GameObject.Find("Brass Ingot Resource Text").GetComponent<Text>();
        steam_engine_resource_text = GameObject.Find("Steam Engine Resource Text").GetComponent<Text>();
        engine_fuel_resource_text = GameObject.Find("Engine Fuel Resource Text").GetComponent<Text>();

        // Alchemy resources

        inventoryUI = GameObject.Find("Inventory");
        minimap = GameObject.Find("Minimap");
        minimapBorder = GameObject.Find("MinimapBorder");

        inventoryUI.gameObject.SetActive(false);
        minimap.gameObject.SetActive(true);
        minimapBorder.gameObject.SetActive(true);

        //store monologue for displaying and hiding
        monologue = GameObject.Find("Monologue");
    }

    // Update is called once per frame
    void Update()
    {
        // Update all text fields
        // Basic resources 
        stone_resource_text.text = "x" + stone;
        iron_ore_resource_text.text = "x" + iron_ore;
        wood_resource_text.text = "x" + wood;
        
        water_resource_text.text = "x" + water;
        crop_resource_text.text = "x" + crop;
        tin_ore_resource_text.text = "x" + tin_ore;
        copper_ore_resource_text.text = "x" + copper_ore;

        //Common resources
        coal_resource_text.text = "x" + coal;
        iron_ingot_resource_text.text = "x" + iron_ingot;
        bucket_resource_text.text = "x" + bucket;

        // Technology resources

        // Construction resources
        tin_ore_resource_text.text = "x" + tin_ore;
        copper_ore_resource_text.text = "x" + copper_ore;
        tin_ingot_resource_text.text = "x" + tin_ingot;
        copper_ingot_resource_text.text = "x" + copper_ingot;
        brass_ingot_resource_text.text = "x" + brass_ingot;
        steam_engine_resource_text.text = "x" + steam_engine;
        engine_fuel_resource_text.text = "x" + engine_fuel;

        // Alchemy resources



        // Open/Close Inventory
        if (Input.GetKeyDown("e") || Input.GetKeyDown(KeyCode.Escape))
        {
            showInventory = !showInventory;

            if(monologue.GetComponent<MonologueManagerScript>().active)
            {
                monologue.SetActive(!monologue.activeSelf);
            }
           
            minimap.gameObject.SetActive(!showInventory);
            minimapBorder.gameObject.SetActive(!showInventory);
            inventoryUI.gameObject.SetActive(showInventory);

            PlayerScript player = GetComponent<PlayerScript>();
            if(player){
                if(showInventory){
                    player.blocked = true;
                    player.loadingBar.gameObject.SetActive(false);
                }
                else
                {
                    player.blocked = false;
                }
            }
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
            oven_upgrade = true;
            Instantiate(oven, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void craftCoal()
    {
        // Required resources
        const int required_wood = 1;

        // Continue only if all requirements are met
        if (wood >= required_wood && oven_upgrade)
        {
            wood -= required_wood;
            coal += 1;
        }
    }

    public void craftIronIngot()
    {
        // Required resources
        const int required_iron_ore = 1;

        // Continue only if all requirements are met
        if (iron_ore >= required_iron_ore && oven_upgrade)
        {
            iron_ore -= required_iron_ore;
            iron_ingot += 1;
        }
    }

    public void craftBucket()
    {
        // Required resources
        const int required_iron_ingot = 4;

        // Continue only if all requirements are met
        if (iron_ingot >= required_iron_ingot)
        {
            iron_ingot -= required_iron_ingot;
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
        const int required_iron_ingot = 4;
        const int required_stone = 8;
        const int required_wood = 16;

        // Continue only if all requirements are met
        if (iron_ingot >= required_iron_ingot && stone >= required_stone && wood >= required_wood)
        {

            iron_ingot -= required_iron_ingot;
            stone -= required_stone;
            wood -= required_wood;

            Instantiate(house, new Vector3(2, 5, 0), Quaternion.identity);
        }
    }

    public void craftMine()
    {
        // Required resources
        const int required_iron_ingot = 8;
        const int required_stone = 8;
        const int required_wood = 8;

        if (iron_ingot >= required_iron_ingot && stone >= required_stone && wood >= required_wood)
        {
            iron_ingot -= required_iron_ingot;
            stone -= required_stone;
            wood -= required_wood;

            Instantiate(mine, new Vector3(20, 27, 0), Quaternion.identity);
        }
    }

    public void craftSawmill()
    {
        // Required resources
        const int required_iron_ingot = 8;
        const int required_stone = 8;
        const int required_wood = 8;

        if (iron_ingot >= required_iron_ingot && stone >= required_stone && wood >= required_wood)
        {
            iron_ingot -= required_iron_ingot;
            stone -= required_stone;
            wood -= required_wood;

            Instantiate(sawmill, new Vector3(-44, 34, 0), Quaternion.identity);
        }
    }


    public void craftTinIngot()
    {
        // Required resources
        const int required_tin_ore = 1;

        if (tin_ore >= required_tin_ore && oven_upgrade)
        {
            tin_ore -= required_tin_ore;
            tin_ingot += 1;
        }
    }


    public void craftCopperIngot()
    {
        // Required resources
        const int required_copper_ore = 1;

        if (copper_ore >= required_copper_ore && oven_upgrade)
        {
            copper_ore -= required_copper_ore;
            copper_ingot += 1;
        }
    }


    public void craftBrassIngot()
    {
        // Required resources
        const int required_copper_ingot = 1;
        const int required_tin_ingot = 1;

        if (copper_ingot >= required_copper_ingot && tin_ingot >= required_tin_ingot && oven_upgrade)
        {
            copper_ingot -= required_copper_ingot;
            tin_ingot -= required_tin_ingot;
            brass_ingot += 1;
        }
    }

    public void crafSteamEngine()
    {
        // Required resources
        const int required_brass_ingot = 8;
        const int required_iron_ingot = 8;

        if (brass_ingot >= required_brass_ingot && iron_ingot >= required_iron_ingot && oven_upgrade)
        {
            brass_ingot -= required_brass_ingot;
            iron_ingot -= required_iron_ingot;
            steam_engine += 1;
        }
    }

    public void crafEngineFuel()
    {
        // Required resources
        const int required_coal = 1;
        const int required_water = 1;

        if (coal >= required_coal && water >= required_water)
        {
            coal -= required_coal;
            water -= required_water;
            engine_fuel += 1;
        }
    }

    public void addResource(string resource_name, int amount)
    {
        switch (resource_name)
        {
            case "Stone":
                stone += amount;
                break;
            case "Iron Ore":
                iron_ore += amount;
                break;
            case "Wood":
                wood += amount;
                break;
            case "Coal":
                coal += amount;
                break;
            case "Water":
                water += amount;
                break;
            case "Crop":
                crop += amount;
                break;
            case "Tin Ore":
                tin_ore += amount;
                break;
            case "Copper Ore":
                copper_ore += amount;
                break;
            default:
                Debug.Log("This resource is not known: " + resource_name);
                break;
        }
    }
}
