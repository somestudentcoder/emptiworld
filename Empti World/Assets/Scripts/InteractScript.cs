using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{

    public void interact(PlayerScript player)
    {
        //find which object it is and interact with it
        if(GetComponent<TreeScript>())
        {
            GetComponent<TreeScript>().interact(player);
        }
        else if(GetComponent<StoneScript>())
        {
            GetComponent<StoneScript>().interact(player);
        }
        else if(GetComponent<FarmingFieldScript>())
        {
            GetComponent<FarmingFieldScript>().interact(player);
        }
        else if(GetComponent<InteractableObjectScript>())
        {
            GetComponent<InteractableObjectScript>().interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
        if(player)
        {
            player.interactPossible = true;
            player.interactor = this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
        if(player)
        {
            player.interactPossible = false;
            player.interactor = null;
        }
    }
}
