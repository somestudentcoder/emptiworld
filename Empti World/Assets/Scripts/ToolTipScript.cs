using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject toolTip;
    public bool makeLastSibling = true;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        toolTip.SetActive(false);
        player = GameObject.Find("Player");
    }

    void OnDisable()
    {
        toolTip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(makeLastSibling){
            transform.SetAsLastSibling();
        }
        
        toolTip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.SetActive(false);
    }
}
