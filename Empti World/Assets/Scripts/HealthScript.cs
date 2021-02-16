using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    private Color green = new Color32(102, 132, 95, 255);
    private Color orange = new Color32(184,99,67, 255);
    private Color red = new Color32(182,92,95, 255);

    public int healthPoints = 100;

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
    }

    public void damage(int dmg)
    {
        if(healthPoints <= 0)
        {
            healthPoints = 0;
            gameOver();
        }
        else
        {
            healthPoints -= dmg;            
        }
        setHealthBarValue();
        setHealthBarColor();
    }

    public void heal(int healing)
    {
        if(healthPoints >= 100)
        {
            healthPoints = 100;
        }
        else
        {
            healthPoints += healing;
        }
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

    private void gameOver() {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

    }
}
