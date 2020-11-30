using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool blocked = false;

    public Vector2 speed = new Vector2(10, 10);
    //public bool interactPossible = false;
    //public InteractScript interactor;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float offsetPlayer = 0.5f;

    private float halfheight; 
    private float halfwidth;

    private Rigidbody2D rigiBody;
    private Vector3 movement;
    private Camera mainCamera;

    void Start()
    {
        if (rigiBody == null) rigiBody = GetComponent<Rigidbody2D>();

        halfheight = Camera.main.orthographicSize;
        halfwidth =  halfheight * Camera.main.aspect;

        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);


        //If in range of an interactable object, give the possibility to interact.
        /*if (interactPossible)
        {
            bool pressed = Input.GetButtonDown("Fire1");
            if(pressed)
            {
                interactor.interact(this);
            }
        }*/
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(this.transform.position + Vector3.down);
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

}
