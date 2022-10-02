using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float TeleportDistance;
    
    private void OnTriggerEnter(Collider other)
    {
        var newPosition = other.transform.position;
        newPosition = new Vector3(newPosition.x, newPosition.y + TeleportDistance, newPosition.z);
        other.transform.position = newPosition;
    }
}
