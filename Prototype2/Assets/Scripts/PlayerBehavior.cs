using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed;

    private float sideInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sideInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * sideInput);

        if(transform.position.x > 16)
        {
            transform.position = new Vector3(16, transform.position.y, transform.position.z);
        }

        if(transform.position.x < -16)
        {
            transform.position = new Vector3(-16, transform.position.y, transform.position.z);
        }
    }
}
