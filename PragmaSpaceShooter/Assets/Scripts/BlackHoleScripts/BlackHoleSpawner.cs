using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpawner : MonoBehaviour
{
    public GameObject blackHolePrefab;

    public float spawnTimer = 1.8f;
    private float currentSpawnTimer = 1.8f;

    public float minX = -2.5f;
    public float maxX = 2.5f;

    public float minScale = .25f;
    public float maxScale = 1f;

    void Start()
    {
        currentSpawnTimer = spawnTimer;
    }

    void Update()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        currentSpawnTimer += Time.deltaTime;


        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        GameObject newBlackHole = null;
        if (currentSpawnTimer >= spawnTimer)
        {
            newBlackHole = Instantiate(blackHolePrefab, temp, Quaternion.identity);
        }

        if (newBlackHole)
        {
            float randomScale = Random.Range(minScale, maxScale);
            newBlackHole.transform.parent = transform;
            newBlackHole.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            
            currentSpawnTimer = 0f;
        }

    }
}
