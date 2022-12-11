/*
* (Kyron Patterson)
* (Assignment 9)
* (Brief description of the code in the file.
* For example: controls player movement)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public GameObject player;
    public float chaseDistance;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromTarget > agent.stoppingDistance && distanceFromTarget < chaseDistance)
        {
            agent.SetDestination(player.transform.position);
            character.Move(agent.desiredVelocity, false, false);
            Debug.Log("Target: Player");
        }
        else
        {
            agent.SetDestination(transform.position);
            character.Move(Vector3.zero, false, false);
            Debug.Log("Target: None " + distanceFromTarget);

        }
    }
}
