using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekScreamer : MonoBehaviour
{
    public GameObject Shrek;
    
    private void OnTriggerEnter(Collider other)
    {
        Shrek.SetActive(true);
        StartCoroutine(waiter());
        waiter();
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        Object.Destroy(gameObject);
        Object.Destroy(Shrek);
    }

}
