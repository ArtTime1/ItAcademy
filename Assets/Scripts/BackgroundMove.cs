using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public PlayerController playerController;
    public float parallaxSpeed = 0.1f;
    public Vector3 StartPosition { get; private set; }
    
    void Start()
    {
        StartPosition = transform.position;
    }

    
    void Update()
    {
        ChangeTurn();
    }

    private void ChangeTurn()
    {
        if (playerController.isMoveRight)
        {
            transform.position = transform.position + new Vector3(parallaxSpeed, 0f, 0f) * -1;
        }
        else
        {
            transform.position = transform.position + new Vector3(parallaxSpeed, 0f, 0f);
        }

    }
}
