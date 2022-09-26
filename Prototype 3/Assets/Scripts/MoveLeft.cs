/*
* (Kyron Patterson)
* (Prototype 3)
* (Moves Obstacles towards the player)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    #region Fields

    private PlayerController playerControllerScript;

    public float speed = 30f;
    private float leftBound = -15;

    #endregion

    private void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Destroy obstacles that go out of bounds to the left.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
