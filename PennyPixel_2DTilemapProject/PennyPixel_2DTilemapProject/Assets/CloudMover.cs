/*
* (Kyron Patterson)
* (Assignment 5A)
* (Moves the clouds in the background of the level, as well as deletes them.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.x <= -35)
        {
            GameObject.Find("Cloud Manager").GetComponent<CloudManager>().cloudAmount--;

            Destroy(gameObject);
        }
    }
}
