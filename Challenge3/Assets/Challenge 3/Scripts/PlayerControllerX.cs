/*
 * (Kyron Patterson)
 * (Challenge 3)
 * (Controls Player Movement, Audio, and replay)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    private bool isLowEnough;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private float tooHigh = 14;
    private float heightLimit = 15;
    private Rigidbody playerRb;
    public ForceMode bounceForce;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    private UIManager uIManager;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Gets the RigidBody from the player.
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        uIManager = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (transform.position.y > tooHigh)
        {
            isLowEnough = false;
        }
        else
        {
            isLowEnough = true;
        }

        if(transform.position.y > heightLimit)
        {
            transform.position = new Vector3(transform.position.x, heightLimit, transform.position.z);
        }

        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        if(other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce/4, bounceForce);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            uIManager.score++;
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
