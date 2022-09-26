/*
 * (Kyron Patterson)
 * (Challenge 3)
 * (Manages and updates the UI in the game.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    private PlayerControllerX player;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        else if(player.gameOver)
        {
            scoreText.text = "Game Over! \nPress R to try again!";
        }
    }
}
