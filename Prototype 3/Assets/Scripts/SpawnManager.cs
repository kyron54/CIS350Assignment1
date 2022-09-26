﻿/*
* (Kyron Patterson)
* (Prototype 3)
* (Manages the spawning of obstacles by choosing from a list and spawning a prefab.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Fields

    private PlayerController playerControllerScript;

    public List<GameObject> objectList;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);

    private float startDelay = 2;
    private float repeateRate = 2;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeateRate);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        int tempObstacle = Random.Range(0, objectList.Count);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(objectList[tempObstacle], spawnPosition, objectList[tempObstacle].transform.rotation);
        }
    }
}
