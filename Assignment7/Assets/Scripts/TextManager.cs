using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public Text scoreWaveText;
    public int score = 0;
    private bool gameStart;

    SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            scoreWaveText.text = "Score: " + score + " Wave: " + spawnManager.waveNumber;

            if (spawnManager.waveNumber >= 10)
            {
                scoreWaveText.text = "You Win! \n" +
                    "Press R to play again!";

                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("Prototype 4");
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStart = true;
        }

        if(gameStart == true)
        {
            Time.timeScale = 1;
        }
        else if(gameStart == false)
        {
            Time.timeScale = 0;
            scoreWaveText.text = "Get to Wave 10 to win!\n" +
                "If you fall off the map, you lose!\n" +
                "Press Space to Start!";
        }
    }
}
