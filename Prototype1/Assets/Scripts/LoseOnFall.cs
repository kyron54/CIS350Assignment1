/*
 * Kyron Patterson
 * Assignment: Prototype 1
 * Description: Changes the text to indicate losing once the player falls off
 *  the road.
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attach this script to the player
public class LoseOnFall : MonoBehaviour
{
    public Text textbox;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -3)
        {
            ScoreManager.gameOver = true;
        }
    }
}
