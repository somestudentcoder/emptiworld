﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool blocked = false;

    public Slider loadingBar;
    public GameObject walkParticles;

    public Vector2 speed = new Vector2(10, 10);
    //public bool interactPossible = false;
    //public InteractScript interactor;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    
    public float miniMapMinX;
    public float miniMapMaxX;
    public float miniMapMinY;
    public float miniMapMaxY;

    public bool damageable = true;
    public float damageCoolDown;
    private float damageTimer;
    public float regenCoolDown;
    private float regenTimer;
    public float hungerCoolDown;
    private float hungerTimer;
    
    public float introTimer;
    private bool intro = true;

    public bool inhouse = false;
    public bool busy = false;

    public bool heatDamageProne = true;
    public bool coldDamageProne = true;

    private float offsetPlayer = 0.5f;

    private float halfheight; 
    private float halfwidth;
    

    private Rigidbody2D rigiBody;
    private Vector3 movement;
    private Camera mainCamera;
    private GameObject gm;
    private Animator animator;
    private SpriteRenderer sprite;
    public Camera miniMapCamera;



    private int wood; 

    void Start()
    {
        
        gm = GameObject.Find("GameManager");
        loadingBar.gameObject.SetActive(false);
        if (rigiBody == null) rigiBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        halfheight = Camera.main.orthographicSize;
        halfwidth =  halfheight * Camera.main.aspect;

        mainCamera = Camera.main;

        damageTimer = damageCoolDown;
        regenTimer = regenCoolDown;
        hungerTimer = hungerCoolDown;
    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX < 0 && sprite.flipX == false && !blocked)
        {
            sprite.flipX = true;
        }
        else if (inputX > 0 && sprite.flipX && !blocked)
        {
            sprite.flipX = false;
        }

        if ((math.abs(inputX) > 0 || math.abs(inputY) > 0) && !blocked)
        {
            animator.SetBool("walking", true);
            walkParticles.SetActive(true);
            SoundEffectsHelperScript.Instance.playWalkingLoop();
        }
        else
        {
            animator.SetBool("walking", false);
            walkParticles.SetActive(false);
            SoundEffectsHelperScript.Instance.stopWalkingLoop();
        }


        movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        //Hunger timer logic
        if(intro)
        {
            introTimer -= Time.deltaTime;
            if(introTimer <= 0)
            {
                intro = false;
            }
        }
        else
        {
            hungerTimer -= Time.deltaTime;
            if(hungerTimer <= 0)
            {
                hunger(10);
                hungerTimer = hungerCoolDown;
            }    
        }
        
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

        //Regen timer logic
        regenTimer += Time.deltaTime;
        if(regenTimer >= regenCoolDown)
        {
            regenTimer = 0;
            heal(20);
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
        
        //Minimap Camera Movement
        if (transform.position.x > miniMapMinX + halfwidth && transform.position.x < miniMapMaxX - halfwidth && transform.position.y > miniMapMinY + halfheight && transform.position.y < miniMapMaxY - halfheight)
        {
            miniMapCamera.transform.position = new Vector3(transform.position[0], transform.position[1], miniMapCamera.transform.position[2]);
        }
        else if (transform.position.x > miniMapMinX + halfwidth && transform.position.x < miniMapMaxX - halfwidth)
        {
            miniMapCamera.transform.position = new Vector3(transform.position[0], miniMapCamera.transform.position[1], miniMapCamera.transform.position[2]);

        }
        else if (transform.position.y > miniMapMinX + halfheight && transform.position.y < miniMapMaxY - halfheight)
        {
            miniMapCamera.transform.position = new Vector3(miniMapCamera.transform.position[0], transform.position[1], miniMapCamera.transform.position[2]);
        }
    }

    public void damage(int dmg)
    {
        damageable = false;
        regenTimer = 0;
        gm.GetComponent<HealthScript>().damage(dmg);
    }

    public void heal(int healing)
    {
        if(gm.GetComponent<HungerScript>().hungerPoints > 50)
        {
            gm.GetComponent<HealthScript>().heal(healing);
        }
    }

    public void hunger(int hun)
    {
        if(damageable && gm.GetComponent<HungerScript>().hungerPoints <= 0)
        {
            damage(10);
        }
        else
        {
            gm.GetComponent<HungerScript>().hunger(hun);
        }
    }

    public void eat(int foodies)
    {
        if(gm.GetComponent<HungerScript>().hungerPoints < 100)
        {
            gm.GetComponent<HungerScript>().eat(foodies);
        }
    }
}
