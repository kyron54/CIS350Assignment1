using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    ScoreCounter sc;

    private void Start()
    {
        sc = GameObject.FindGameObjectWithTag("Score Text").GetComponent<ScoreCounter>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dog"))
        {
            sc.score++;
        }

        Destroy(gameObject);
    }
}
