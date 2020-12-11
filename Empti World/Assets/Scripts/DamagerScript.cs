using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<PlayerScript>().damageable)
            col.gameObject.GetComponent<PlayerScript>().damage(20);
    }
}
