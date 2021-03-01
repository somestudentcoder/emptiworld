using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{

    private GameObject map;
    private GameObject mapBorder;
    private GameObject miniMap;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map");
        mapBorder = GameObject.Find("MapBorder");
        miniMap = GameObject.Find("Minimap");
        map.gameObject.SetActive(false);
        mapBorder.gameObject.SetActive(false);
    }

    public void OpenMap()
    {
        map.gameObject.SetActive(true);
        mapBorder.gameObject.SetActive(true);
        miniMap.SetActive(false);
    }

    public void CloseMap()
    {
        map.gameObject.SetActive(false);
        mapBorder.gameObject.SetActive(false);
        miniMap.SetActive(true);
    }
    
}
