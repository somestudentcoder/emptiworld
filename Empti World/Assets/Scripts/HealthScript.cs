using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private Color green = new Color(0,176,0);
    private Color orange = new Color(255,110,0);
    private Color red = new Color(253,0,0);

    public int healthPoints = 100;
    private float second = 1.0f;

    public bool continousDamageEnabled = false;
    public int continousDamage;

    private GameObject Bar;
    private GameObject Fill;

    // Start is called before the first frame update
    void Start()
    {
        Bar = GameObject.Find("Health Bar");
        Fill = GameObject.Find("Health Bar Fill");
    }

    // Update is called once per frame
    void Update()
    {
        if(continousDamageEnabled)
        {
            second -= Time.deltaTime;
            if(second <= 0)
            {
                damage(continousDamage);
                second = 1.0f;
            }
        }
    }

    public void damage(int dmg)
    {
        healthPoints -= dmg;
        setHealthBarValue();
        setHealthBarColor();
    }

    public void heal(int healing)
    {
        healthPoints += healing;
        setHealthBarValue();
        setHealthBarColor();
    }

    private void setHealthBarColor()
    {
        if(healthPoints > 50)
        {
            Fill.GetComponent<Image>().color = green;
        }
        else if(healthPoints > 25)
        {
            Fill.GetComponent<Image>().color = orange;
        }
        else
        {
            Fill.GetComponent<Image>().color = red;
        }
    }

    private void setHealthBarValue()
    {

        Bar.GetComponent<Slider>().value = healthPoints;
    }
}
