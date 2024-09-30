using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    private float countDown;
    public float timeBetweenSpawns;
    public bool enableSpawning;

    private float timeSinceLastSpawn;
    void Awake()
    {
       countDown = timeBetweenSpawns;
        enableSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSpawning == true)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                Instantiate(pipePrefab, new Vector3(10, Random.Range(-1.5f, 9.0f), 0), Quaternion.identity);
                countDown = timeBetweenSpawns;
            }
        }
    }
}
