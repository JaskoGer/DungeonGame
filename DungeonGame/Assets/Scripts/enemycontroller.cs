using System.Collections;
using static System.Console;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
	public float lookRadius = 15f;
	public float attackDistance = 3f;
	public float movementSpeed = 5f;
	public Vector3 patrolDest;
	public bool hasPatrolDest = false;
	public float enemyHP = 50;
	
	Transform target;
	NavMeshAgent agent;
	

    // Start is called before the first frame update
    void Start()
    {
		target = PlayerManager.instance.player.transform;
		// setting attributes
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.stoppingDistance = attackDistance;
		agent.speed = movementSpeed;
    }


    // Update is called once per frame
    void Update()
    {
		// Distance between Player and enemy
		float distance = Vector3.Distance(target.position, transform.position);

		// if enemy has visual on player, calls ChasePlayer method
		if (hasVisual(distance))
        {
			print("Coming for you");
			hasPatrolDest = false;
			ChasePlayer();
			
        }

		// if not near player, calls Patroling method
		else
        {
			print("going Patroling");
			Patroling();
        }	
    }


	/**
	 * Checks if player is close by, than casts racasts which check in the field of visibilty wheter or not the player is visible for the enemy
	 */
	bool hasVisual(float distance)
    {
		RaycastHit hit;
		if (distance <= lookRadius)
        {
			Vector3 addDegree = new Vector3(0, 1, 0);
			Vector3 raycastDir = transform.localEulerAngles;
			
			for (int i = 0; i < 9; i++)
            {
				if (Physics.Raycast(transform.position, Quaternion.Euler(raycastDir + addDegree * i * 10) * Vector3.forward, out hit, lookRadius))
                {
					if (hit.transform == target)
                    {
						if (distance <= attackDistance)  AttackPlayer();
						return true;
                    }
                }
				if (Physics.Raycast(transform.position, Quaternion.Euler(raycastDir - addDegree * i * 10) * Vector3.forward, out hit, lookRadius))
                {
					if (hit.transform == target)
					{
						if (distance <= attackDistance) AttackPlayer();
						return true;
					}
				}
            }
        }
		return false;
    }
	

	private void Patroling()
    {
		Vector3 loc = transform.TransformVector(transform.position[0], transform.position[1], transform.position[2]);

		if (!hasPatrolDest)
		{
			print("looking for a position");
			patrolDest = new Vector3(transform.position[0] + Random.Range(-50f, 50), transform.position[1], transform.position[2] + Random.Range(-50, 50));
			hasPatrolDest = true;
		}

	//	else if (patrolDest.Equals(transform.position.normalized))
	//    else if (patrolDest.normalized == transform.position.normalized)
	//	else if (patrolDest[0] - transform.TransformVector[0] <= 1f && patrolDest[2] - transform.TransformVector[2] <= 1f)
	//	else if (patrolDest[0] - loc[0] <= 2f && patrolDest[2] - loc[2] <= 2f)
    	else if ((patrolDest.normalized - transform.position.normalized).magnitude <= 0.5)
	//    else if (agent.remainingDistance <= 1f)
		{
			print("found my spot");
			hasPatrolDest = false;
        }

		else
        {
			print("Going to position: " + agent.remainingDistance);
			Vector3 direction = (patrolDest - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
			transform.rotation = lookRotation;
			agent.SetDestination(patrolDest);
		}
    }


	private void ChasePlayer()
    {
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = lookRotation;
		agent.SetDestination(target.position);
	}


	void AttackPlayer()
    {
		print("I punched you in the face you A-hole!");
    }
}
