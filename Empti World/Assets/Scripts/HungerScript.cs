using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerScript : MonoBehaviour
{
	private Color yellow = new Color32(190, 150, 37, 255);
    private Color orange = new Color32(184,99,67, 255);
    private Color red = new Color32(182,92,95, 255);

    public int hungerPoints = 100;

    private GameObject Bar;
    private GameObject Fill;

    // Start is called before the first frame update
    void Start()
    {
        Bar = GameObject.Find("Hunger Bar");
        Fill = GameObject.Find("Hunger Bar Fill");
    }

    public void hunger(int hun)
    {
        if(hungerPoints <= 0)
        {
            hungerPoints = 0;
        }
        else
        {
            hungerPoints -= hun;            
        }
        setHungerBarValue();
        setHungerBarColor();
    }

    public void eat(int foodies)
    {
        if(hungerPoints >= 100)
        {
            hungerPoints = 100;
        }
        else
        {
        	if(GameObject.Find("Player").GetComponent<InventoryScript>().crop >= 1)
        	{
        		hungerPoints += foodies;
        		GameObject.Find("Player").GetComponent<InventoryScript>().crop -= 1;
        	}
        }
        setHungerBarValue();
        setHungerBarColor();
    }

    private void setHungerBarColor()
    {
        if(hungerPoints > 50)
        {
            Fill.GetComponent<Image>().color = yellow;
        }
        else if(hungerPoints > 25)
        {
            Fill.GetComponent<Image>().color = orange;
        }
        else
        {
            Fill.GetComponent<Image>().color = red;
        }
    }

    private void setHungerBarValue()
    {

        Bar.GetComponent<Slider>().value = hungerPoints;
    }
}
