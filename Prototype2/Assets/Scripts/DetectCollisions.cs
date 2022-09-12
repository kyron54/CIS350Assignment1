using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScore;

    private void Start()
    {
        displayScore = GameObject.FindGameObjectWithTag("Display Score Text").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            displayScore.score++;

            Destroy(other.gameObject);

            Destroy(gameObject);
        }
    }
}
