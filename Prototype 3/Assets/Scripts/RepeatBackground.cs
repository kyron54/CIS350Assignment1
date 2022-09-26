/*
* (Kyron Patterson)
* (Prototype 3)
* (Moves Obstacles towards the player)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    #region Fields
    private Vector3 startPosition;
    private float repeatWidth;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Save the starting position of the background to a Vector3 variable.
        startPosition = transform.position;

        // Set the repeatWidth to half of the width of the background using the BoxCollider.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // if the background is further to the left than the repeatWidth, reset it to its StartPosition.
        if(transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
