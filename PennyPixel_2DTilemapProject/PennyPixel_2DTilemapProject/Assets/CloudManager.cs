/*
* (Kyron Patterson)
* (Assignment 5A)
* (Spawns clouds randomly.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public List<GameObject> cloudsList;
    public List<Transform> spawnPoints;

    public int cloudAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnClouds", 2, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnClouds()
    {

            cloudAmount++;

            int cloudType = Random.Range(0, cloudsList.Count);
            int spawnPos = Random.Range(0, spawnPoints.Count);

            Transform tempPos = spawnPoints[spawnPos];

            Instantiate(cloudsList[cloudType], tempPos);
    }

    IEnumerator SpawnCloudRoutine()
    {
        yield return new WaitForSeconds(2f);      
        
    }
}
