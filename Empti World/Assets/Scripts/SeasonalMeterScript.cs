using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonalMeterScript : MonoBehaviour
{
    public GameObject seasonal_meter;

    public GameObject seasonal_meter_position;

    public float game_time = 600;

    public GameObject minimap;

    public GameObject inventory;

    public GameObject end;
    
    private Vector3 start_position;
    private Vector3 target;
    private float t;
    
    
    // Start is called before the first frame update
    void Start()
    {
        start_position = seasonal_meter_position.transform.position;
        RectTransform position = seasonal_meter.GetComponent<RectTransform>();
        Image image = seasonal_meter.GetComponent<Image>();
        Debug.Log(start_position);
        target =   end.transform.position;
        target.y = start_position.y;
        Debug.Log(target);
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime/game_time;
        seasonal_meter_position.transform.position = Vector3.Lerp(start_position, target, t);
        
        if (inventory.activeSelf || minimap.activeSelf)
        {
            seasonal_meter.GetComponent<Image>().enabled = false;
            seasonal_meter_position.GetComponent<Image>().enabled = false;
        }
        else
        {
            seasonal_meter.GetComponent<Image>().enabled = true;
            seasonal_meter_position.GetComponent<Image>().enabled = true;
        }
    }
}
