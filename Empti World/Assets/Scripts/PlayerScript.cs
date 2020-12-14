﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool blocked = false;

    public Slider loadingBar;

    public Vector2 speed = new Vector2(10, 10);
    //public bool interactPossible = false;
    //public InteractScript interactor;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public bool damageable = true;
    public float damageCoolDown;
    private float damageTimer;

    private float offsetPlayer = 0.5f;

    private float halfheight; 
    private float halfwidth;
    

    private Rigidbody2D rigiBody;
    private Vector3 movement;
    private Camera mainCamera;
    private GameObject gm;



    private int wood; 

    void Start()
    {
        gm = GameObject.Find("GameManager");
        loadingBar.gameObject.SetActive(false);
        if (rigiBody == null) rigiBody = GetComponent<Rigidbody2D>();

        halfheight = Camera.main.orthographicSize;
        halfwidth =  halfheight * Camera.main.aspect;

        mainCamera = Camera.main;

        damageTimer = damageCoolDown;
    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        //Damage timer logic
        if(damageable == false)
        {
            damageTimer -= Time.deltaTime;
            if(damageTimer <= 0)
            {
                damageTimer = damageCoolDown;
                damageable = true;
            }
        }


        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log(this.transform.position + Vector3.down);
            Collider2D hit = Physics2D.OverlapCircle(this.transform.position + Vector3.down, 0.3f, LayerMask.GetMask("Interactable Objects"));
            if (hit != null)
            {
                Debug.Log(hit.transform.position);
                InteractScript script = hit.GetComponent<InteractScript>();
                if (script != null)
                {
                    script.interact(this);
                }
            }
        }
    }

    void FixedUpdate()
    {   
        if(blocked)
        {
            rigiBody.velocity = new Vector2(0,0);
            return;
        }

        //Player Movement
        rigiBody.velocity = movement;
        if(transform.position.y > maxY - offsetPlayer)
        {
            transform.position = new Vector2(transform.position.x, maxY - offsetPlayer);
        }
        else if(transform.position.y < minY + offsetPlayer)
        {
            transform.position = new Vector2(transform.position.x, minY  + offsetPlayer);
        }
        if(transform.position.x > maxX - offsetPlayer)
        {
            transform.position = new Vector2(maxX - offsetPlayer, transform.position.y);
        }
        else if(transform.position.x < minX + offsetPlayer)
        {
            transform.position = new Vector2(minX + offsetPlayer, transform.position.y);
        }

        //Camera Movement
        if (transform.position.x > minX + halfwidth && transform.position.x < maxX - halfwidth && transform.position.y > minY + halfheight && transform.position.y < maxY - halfheight)
        {
            mainCamera.transform.position = new Vector3(transform.position[0], transform.position[1], mainCamera.transform.position[2]);
        }
        else if (transform.position.x > minX + halfwidth && transform.position.x < maxX - halfwidth)
        {
            mainCamera.transform.position = new Vector3(transform.position[0], mainCamera.transform.position[1], mainCamera.transform.position[2]);

        }
        else if (transform.position.y > minY + halfheight && transform.position.y < maxY - halfheight)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position[0], transform.position[1], mainCamera.transform.position[2]);
        }
    }

    public void damage(int dmg)
    {
        damageable = false;
        gm.GetComponent<HealthScript>().damage(dmg);
    }

    public void heal(int healing)
    {
        gm.GetComponent<HealthScript>().heal(healing);
    }
}
