using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    HealthText hp;

    private float leftLimit = -30;
    private float bottomLimit = -5;

    private void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Health Text").GetComponent<HealthText>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            hp.health--;

            Destroy(gameObject);
        }

    }
}
