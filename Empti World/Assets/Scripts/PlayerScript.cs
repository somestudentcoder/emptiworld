using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public bool interactPossible = false;
    public InteractScript interactor;
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.Translate(movement);

        if(interactPossible)
        {
            bool pressed = Input.GetButtonDown("Fire1");
            if(pressed)
            {
                interactor.interact();
            }
        }
    }

}
