using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{

    private GameObject map;
    private GameObject mapBorder;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map");
        mapBorder = GameObject.Find("MapBorder");
        map.gameObject.SetActive(false);
        mapBorder.gameObject.SetActive(false);
    }

    public void OpenMap()
    {
        map.gameObject.SetActive(true);
        mapBorder.gameObject.SetActive(true);
    }

    public void CloseMap()
    {
        map.gameObject.SetActive(false);
        mapBorder.gameObject.SetActive(false);
    }
    
}
