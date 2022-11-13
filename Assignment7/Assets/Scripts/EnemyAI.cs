using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject player;
    TextManager textManager;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        textManager = GameObject.Find("Text Manager").GetComponent<TextManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.y < -10)
        {
            textManager.score++;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //vector for direction from enemy to player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //Add force towards player
        enemyRb.AddForce(lookDirection * speed);
    }
}
