using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public bool interactPossible = false;
    public InteractScript interactor;

    public float minX = -3.1f;
    public float maxX = 5.1f;
    public float minY = -2f;
    public float maxY = 2f;


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);
        GameObject camera = GameObject.Find("Main Camera");
        if (transform.position.x > minX && transform.position.x < maxX && transform.position.y > minY && transform.position.y < maxY)
        {
            camera.transform.position = new Vector3(transform.position[0], transform.position[1], camera.transform.position[2]);
        }
        else if (transform.position.x > minX && transform.position.x < maxX)
        {
            camera.transform.position = new Vector3(transform.position[0], camera.transform.position[1], camera.transform.position[2]);

        }
        else if (transform.position.y > minY && transform.position.y < maxY)
        {
            camera.transform.position = new Vector3(camera.transform.position[0], transform.position[1], camera.transform.position[2]);
        }


        //If in range of an interactable object, give the possibility to interact.
        if (interactPossible)
        {
            bool pressed = Input.GetButtonDown("Fire1");
            if(pressed)
            {
                interactor.interact();
            }
        }
    }

}
