/*
* (Kyron Patterson)
* (Assignment 5A)
* (Respawns player if they fall beneath the map.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRestart : MonoBehaviour
{
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -16)
        {
            transform.position = startPos;
        }
    }
}
