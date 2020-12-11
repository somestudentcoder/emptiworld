using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{

    public void interact(PlayerScript player)
    {
        player.loadingBar.gameObject.SetActive(true);
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPos = cam.WorldToScreenPoint(player.transform.position);
        player.loadingBar.transform.position = screenPos + new Vector3(0, 60, 0);


        //find which object it is and interact with it
        if (GetComponent<TreeScript>())
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
}
