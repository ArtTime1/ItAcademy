using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamers : MonoBehaviour
{ 
    [SerializeField] private GameObject[] ScreamersPr;
    [SerializeField] private Transform player;
    [SerializeField] private float minDistanceFromPl;
    [SerializeField] private float maxDistanceFromPl;
    [SerializeField] private int minSpawnTime;
    [SerializeField] private int maxSpawnTime;
   
    private float timer;
    private float timeSpawn;

    private void Start()
    {
        timeSpawn = Random.Range(minSpawnTime, maxSpawnTime);
      ;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeSpawn)
        {
            Vector3 position = new Vector3(Random.Range(minDistanceFromPl, maxDistanceFromPl), Random.Range(minDistanceFromPl, maxDistanceFromPl), Random.Range(minDistanceFromPl, maxDistanceFromPl));
            gameObject.transform.position = position;
            Instantiate(ScreamersPr[Random.Range(0, ScreamersPr.Length)], position, Quaternion.identity, transform);
            timeSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timer = 0;
        }
    }
}
