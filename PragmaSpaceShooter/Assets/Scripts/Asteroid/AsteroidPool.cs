using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    public int asteroidPoolSize = 3;
    public GameObject asteroidPrefab;
    public float spawnRate = 4f;
    public float asteroidMin = -2.65f;
    public float asteroidMax = 2.65f;

    private GameObject[] asteroids;
    private float timeSinceLastSpawned = 0f;
    private float spawnYPosition = 5.6f;
    private int currentAsteroidIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpawn();
    }

    void Init()
    {
        asteroids = new GameObject[asteroidPoolSize];
        timeSinceLastSpawned = spawnRate;
    }

    void CheckSpawn()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned > spawnRate)
        {
            timeSinceLastSpawned = 0;

            float spawnXPosition = GenerateXPosition();
            Vector2 position = new Vector2(spawnXPosition, spawnYPosition);

            GameObject currentAsteroid;
            if (asteroids[currentAsteroidIndex] == null)
            {
                currentAsteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
                asteroids[currentAsteroidIndex] = currentAsteroid;
            }
            else
            {
                currentAsteroid = asteroids[currentAsteroidIndex];
                currentAsteroid.transform.position = position;
            }

            RandomizeMesh(currentAsteroid);

            currentAsteroidIndex++;
            if (currentAsteroidIndex >= asteroidPoolSize)
            {
                currentAsteroidIndex = 0;
            }
        }
    }

    float GenerateXPosition()
    {
        return Random.Range(asteroidMin, asteroidMax);
    }

    void RandomizeMesh(GameObject currentAsteroid)
    {
        MeshRenderer mesh = currentAsteroid.GetComponent<MeshRenderer>();
        mesh.material = mesh.materials[Random.Range(0, mesh.materials.Length)];
    }
}
