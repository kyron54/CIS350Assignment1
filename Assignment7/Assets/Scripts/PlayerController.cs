using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    private TextManager textManager;
    public float speed = 5.0f;
    bool hasDied = false;

    public bool hasPowerup = false;
    private float powerupStrength = 15.0f;
    private float pushStrength = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("Focal Point");
        textManager = GameObject.Find("Text Manager").GetComponent<TextManager>();
    }

    private void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -10)
        {
            hasDied = true;
            textManager.scoreWaveText.text = "You Lost! \n Retry by pressing R!";
        }

        if(hasDied == true)
        {
            Time.timeScale = 0;

            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Prototype 4");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());

            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sets a local reference to the enemy Rigidbody
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        // Sets a Vector3 with a direction away from the player
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player collided with: " + collision.gameObject.name +
                " with powerup set to " + hasPowerup); 

            //Add an Impulse force to the enemy away from the player
            //(an Impulse force is instant and uses mass)
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Sets a local reference to the enemy Rigidbody
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        // Sets a Vector3 with a direction away from the player
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

        if (collision.gameObject.CompareTag("Enemy") && !hasPowerup)
        {
            Debug.Log("Impact!");

            if (Input.GetKeyDown(KeyCode.F))
            {
                enemyRigidbody.AddForce(awayFromPlayer * pushStrength, ForceMode.Impulse);
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
