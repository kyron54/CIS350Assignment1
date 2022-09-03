/*
 * Kyron Patterson
 * Assignment: Challenge 1
 * Description: Adds to the score each time a trigger is passed.
 *  The trigger is deleted once it is activated.
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to a trigger zone
public class TriggerScoreAdd : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = false;
            Destroy(gameObject);
        }
    }
}
