/*
 * Kyron Patterson
 * Assignment: Challenge 1
 * Description: Manages the score and the win condition of the player.
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool won = false;
    public static int score = 0;

    public Text textbox;

    // Start is called at the first frame
    private void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is not over, display score.
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        //win condition: 3 or more points
        if (score >= 5)
        {
            won = true;
            gameOver = true;
        }

        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You Win!\nPress 'R' to Play Again!";
            }
            else
            {
                textbox.text = "You lose!\nPress 'R' to Try Again!";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
