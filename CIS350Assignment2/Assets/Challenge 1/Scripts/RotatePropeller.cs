/*
 * Kyron Patterson
 * Assignment: Challenge 1
 * Description: Rotates the propeller of the Plane.
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    public float rotSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotSpeed * Time.deltaTime);
    }
}
