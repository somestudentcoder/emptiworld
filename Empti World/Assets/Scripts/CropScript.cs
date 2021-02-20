using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropScript : MonoBehaviour
{
    public Sprite grownSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void grow()
    {
        GetComponent<SpriteRenderer>().sprite = grownSprite;
        //transform.position += Vector3.up * 0.5f;
    }
}
