using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public HealthSystem healthSystem;

    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    private void Start()
    {
        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);
        StartCoroutine(SpawnRandomPrefabCoroutine());
        healthSystem = GameObject.FindGameObjectWithTag("Health System").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomPrefab()
    {
        // Pick a random animal to spawn
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        // generate a random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        // Spawn our animal
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }

    IEnumerator SpawnRandomPrefabCoroutine()
    {
        //add 3 second delay before first spawning objects
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            float randomDelay = Random.Range(1.5f, 3.0f);

            yield return new WaitForSeconds(randomDelay);
        }
    }
}
