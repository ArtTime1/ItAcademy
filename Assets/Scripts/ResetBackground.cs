using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBackground : MonoBehaviour
{
    public BackgroundMove backgroundMove;
    public Transform Background;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ninja")
        {
            Background.position = backgroundMove.StartPosition;
        }
    }
}
