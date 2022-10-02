using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;    
    public float speed = 15f;
    float gravity = -9.81f;
    bool isMoving = false;
    public GameObject FootSteps;
     
    void Update()
    {           
        Movement();
        StepsSound();
    }

    private void Movement()
    {  
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal * speed, gravity, vertical * speed);

       controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
    }

    private void StepsSound()
    {
        if(controller.velocity.x != 0)
        {
            isMoving = true;           
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            FootSteps.SetActive(true);

        }
        else
        {
            FootSteps.SetActive(false);

        }
    }
}
