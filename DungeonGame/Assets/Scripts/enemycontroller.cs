using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
	public float attackDistance = 3f;
	public float movementSpeed = 20f;
	public float enemyHP = 50;
	
	public Transform playerTransform;
	UnityEngine.AI.NavMeshAgent agent;
	
    // Start is called before the first frame update
    void Start()
    {   
		// setting attributes
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.stoppingDistance = attackDistance;
		agent.speed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the player   
		playerTransform = GetComponent<Transform>();
		agent.destination = playerTransform.position;
		
		
		// Direction of view
		transform.LookAt(new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y, playerTransform.transform.position.z));
		
		
	
    }
}
