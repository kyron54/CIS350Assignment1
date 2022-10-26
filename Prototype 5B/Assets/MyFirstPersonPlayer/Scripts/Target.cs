using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    ScoreText st;

    private void Start()
    {
        st = GameObject.Find("Canvas").GetComponent<ScoreText>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(st.score);
        st.score++;
        Destroy(gameObject);
    }

}
