using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawningScript : MonoBehaviour
{
    public Sprite standardRock;
    public Sprite tinRock;
    public Sprite copperRock;
    public Sprite ironRock;

    public GameObject stone;
    public GameObject tinOre;
    public GameObject copperOre;
    public GameObject ironOre;

    public int tinRocksCount = 2;
    public int copperRocksCount = 2;
    public int ironRocksCount = 2;
    
    public int spawnCooldownSec = 5;
    
    // Start is called before the first frame update
    void Start()
    {
       initResources();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void specialDepleted(GameObject rock, string resource_name)
    {
        rock.GetComponent<SpriteRenderer>().sprite = standardRock;
        StoneScript script = rock.GetComponent<StoneScript>();
        script.isSpecial = false;
        script.rock = stone;
        StartCoroutine(waitforCooldown(resource_name));
    }

    public void setNewSpecialResource(string resource_name, GameObject rock)
    {
        StoneScript script = rock.GetComponent<StoneScript>();
        script.isSpecial = true;
        script.specialName = resource_name;
        script.specialMineralCount = 0;
        switch (resource_name)
        {
            case "Tin":
                //Debug.Log("Spawning Tin");
                script.rock = tinOre;
                rock.GetComponent<SpriteRenderer>().sprite = tinRock;
                break;
            case "Copper":
                //Debug.Log("Spawning Copper");
                script.rock = copperOre;
                rock.GetComponent<SpriteRenderer>().sprite = copperRock;
                break;
            case "Iron":
                script.rock = ironOre;
                rock.GetComponent<SpriteRenderer>().sprite = ironRock;
                break;
        }
    }


    void createRandomSpecial(string resource_name)
    {
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Stone");
        int random = Random.Range(0, rocks.Length);
        StoneScript script = rocks[random].GetComponent<StoneScript>();
        while (script.isSpecial)
        {
            random = Random.Range(0, rocks.Length);
            script = rocks[random].GetComponent<StoneScript>();
        }
        setNewSpecialResource(resource_name, rocks[random]);
    }
    
    
    void initResources()
    {
        for (int i = 0; i < tinRocksCount; i++)
        {
            createRandomSpecial("Tin");
        }
        for (int i = 0; i < copperRocksCount; i++)
        {
            createRandomSpecial("Copper");
        }
        for (int i = 0; i < ironRocksCount; i++)
        {
            createRandomSpecial("Iron");
        }
    }

    IEnumerator waitforCooldown(string resource_name)
    {
        yield return new WaitForSecondsRealtime(spawnCooldownSec);
        createRandomSpecial(resource_name);
    }
}
