/*
* (Kyron Patterson)
* (Prototype 3)
* (Increments the score in UIManager.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAddScore : MonoBehaviour
{
    private UIManager uIManager;

    private bool triggered = false;

    private void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            uIManager.score++;
        }
    }
}
