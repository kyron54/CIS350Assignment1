/*
* (Kyron Patterson)
* (Assignment 5A)
* (Triggers the Win text.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinBehavior : MonoBehaviour
{
    TextManager tM;

    private void Start()
    {
        tM = GameObject.Find("Text Manager").GetComponent<TextManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tM.scoreText.text = "You Win!";
            Debug.Log("You Win!");
        }
    }
}
