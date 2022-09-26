/*
* (Kyron Patterson)
* (Prototype 3)
* (controls player movement and Animations.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    private Rigidbody rb;
    private Animator playerAnimator;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Set reference variable to components.
        rb = GetComponent<Rigidbody>();

        playerAnimator = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();

        // Modify gravity

        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        //Start Running
        playerAnimator.SetFloat("Speed_f", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);

            // Set the trigger to play the jump animation.
            playerAnimator.SetTrigger("Jump_trig");

            isOnGround = false;

            //Play Jump Sound effect.
            playerAudio.PlayOneShot(jumpSound, 0.8f);

            // Stop dirt particle effect.
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        if(collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            //Play Crash Sound effect.
            playerAudio.PlayOneShot(crashSound, 0.8f);

            //Play death animation
            explosionParticle.Play();
            dirtParticle.Stop();

            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }
}
