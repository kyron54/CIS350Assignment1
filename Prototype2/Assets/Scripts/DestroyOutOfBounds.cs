using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem hs;

    private void Start()
    {
        hs = GameObject.FindGameObjectWithTag("Health System").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.z < bottomBound)
        {
            hs.TakeDamage();

            Destroy(gameObject);
        }
    }
}
