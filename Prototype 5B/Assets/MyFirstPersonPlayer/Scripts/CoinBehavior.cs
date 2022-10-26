using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public float speed = 2;
    ScoreText st;

    // Start is called before the first frame update
    void Start()
    {
        st = GameObject.Find("Canvas").GetComponent<ScoreText>();  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1 * Time.deltaTime * speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            st.win = true;
            Destroy(gameObject);
        }
    }
}
