/*
* (Kyron Patterson)
* (Assignment 5A)
* (Handles the movements of Platforms, depending on the platform type.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float speed = 5;

    public int maxTranslate;

    public int platformType;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startingPos = transform.position;

        Physics2D.IgnoreLayerCollision(10, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if(platformType == 1)
        {
            MoveUp();
        }

        if(platformType == 2)
        {
            MoveSide();
        }

        if(platformType == 3)
        {
            if (transform.position.y < -16)
            {
                rb2d.gravityScale = 0;
                rb2d.velocity = new Vector2(0, 0);
                transform.position = startingPos;
            }
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(transform.position.y > startingPos.y + maxTranslate)
        {
            speed = -speed;
        }

        if(transform.position.y < startingPos.y - maxTranslate)
        {
            speed = Mathf.Abs(speed);
        }

    }

    void MoveSide()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x >= startingPos.x + maxTranslate)
        {
            speed = -speed;
        }

        if (transform.position.x <= startingPos.x - maxTranslate)
        {
            speed = Mathf.Abs(speed);
        }
    }

    void FallPlat()
    {
        rb2d.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (platformType == 1 || platformType == 2)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.parent = gameObject.transform;
            }
        }

        if (platformType == 3)
        {
            Invoke("FallPlat", 1f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
