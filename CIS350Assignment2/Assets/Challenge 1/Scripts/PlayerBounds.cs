/*
 * Kyron Patterson
 * Assignment: Challenge 1
 * Description: Establishes the player boundaries for the lose condition.
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -51 || transform.position.y >= 65)
        {
            ScoreManager.gameOver = true;
            rb.useGravity = true;
        }
    }
}
