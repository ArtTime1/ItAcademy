using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isMoveRight { get; private set; }
    private SpriteRenderer SpriteRenderNinja { get { return spriteRenderer = spriteRenderer ?? GetComponent<SpriteRenderer>(); } }

    void Start()
    {
        isMoveRight = true;
    }
  
    void Update()
    {
        Debug.Log(isMoveRight);
        MovementAndFlip();
    }

    private void MovementAndFlip()
    {
        if (isMoveRight)
        {
            var position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.position = position;
        }
        else
        {
            var position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpriteRenderNinja.flipX = !SpriteRenderNinja.flipX;
            isMoveRight = !isMoveRight;
        }
    }
}
