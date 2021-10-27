using System.Collections;
using static System.Console;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
/**
 * erstellt und bearbeitet von JASKO und JONAS
 * Erstellung der Klasse EnemyController und Deklarierung der Variablen
 */
public class EnemyController : MonoBehaviour
{
	public float lookRadius = 15f;
	public float attackDistance = 2f;
	public float movementSpeed = 5f;
	public float attackSpeed = 0.5f;
	public float attackDamage = 5f;
	public Vector3 patrolDest;
	public bool hasPatrolDest = false;
	public float enemyHP = 50;
	public float attackCooldown = 0f;
	private float patrolCooldown = 0f;

	Transform target;
	NavMeshAgent agent;


	/**
	 * erstellt und bearbeitet von JASKO
	 * Methode Start() wird vor dem ersten geladenen Bild aufgerufen
	 * setzt die Attribute für das Mob
	 */
	void Start()
	{
		target = PlayerManager.instance.player.transform;
		// setzen der Attribute
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.stoppingDistance = attackDistance;
		agent.speed = movementSpeed;
	}

	/**
	 * erstellt von JASKO
	 * bearbeitet von TOBIAS und JONAS
	 */
	// Update wird einmal pro Frame aufgerufen
	void Update()
	{
		// berechnet den Abstant zwischen dem Mob und dem Player
		float distance = Vector3.Distance(target.position, transform.position);

		// setzt und überprüft den Cooldown
		if (attackCooldown > 0)
		{
			attackCooldown -= Time.deltaTime;
			if (attackCooldown < 0)
				attackCooldown = 0;
		}

		if (patrolCooldown > 0)
		{
			patrolCooldown -= Time.deltaTime;
			if (patrolCooldown < 0)
				patrolCooldown = 0;
		}


		// wenn das Mob Sichtkontakt zum Player hat, wird die ChasePlayer Methode aufgerufen
		if (hasVisual(distance))
		{
			agent.speed = movementSpeed;
			hasPatrolDest = false;
			ChasePlayer();
		}

		// wenn kein Player gefunden wird, wird die Patrolling Methode aufgerufen
		else
		{
			agent.speed =movementSpeed * 0.6f;
			Patroling();
		}
	}


	/**
	 * erstellt von JASKO
	 * überarbeitet und verbessert von JONAS
	 *Prüft ob ein Player in der Nähe ist und überprüft dann, ob nichts die Sicht des Mobs auf den Player blockiert
	 */

	bool hasVisual(float distance)
	{
		RaycastHit hit;
		if (distance <= lookRadius)
		{
			Quaternion qRaycastDir = Quaternion.LookRotation(target.position - transform.position);
			Vector3 raycastDir = qRaycastDir.eulerAngles;
			Vector3 addDegree = new Vector3(0, 1, 0);
			float angle = Quaternion.Angle(transform.rotation, qRaycastDir);

			for (int i = 0; i < 9; i++)
			{
				if (Physics.Raycast(transform.position, Quaternion.Euler(raycastDir + addDegree * i * 1) * Vector3.forward, out hit, lookRadius))
				{
					if (hit.transform == target)
					{
						if (distance <= attackDistance && attackCooldown <= 0)
						{
							AttackPlayer();
							setAttackCooldown();
						}

						return true;
					}
				}
				if (Physics.Raycast(transform.position, Quaternion.Euler(raycastDir - addDegree * i * 1) * Vector3.forward, out hit, lookRadius))
				{
					if (hit.transform == target)
					{
						if (distance <= attackDistance && attackCooldown == 0)
						{
							AttackPlayer();
							setAttackCooldown();
						}
						return true;
					}
				}
			}
		}
		return false;
	}


	private void Patroling()
	{
		if (!hasPatrolDest)
		{
			patrolDest = new Vector3(transform.position[0] + Random.Range(-10f, 10), transform.position[1], transform.position[2] + Random.Range(-10, 10));
			hasPatrolDest = true;
		}

		else if (Vector3.Distance(patrolDest.normalized, transform.position.normalized) <= 0.02f)
		{
			hasPatrolDest = false;
		}

		else if (patrolCooldown == 0)
		{
			Vector3 direction = (patrolDest - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
			transform.rotation = lookRotation;
			agent.SetDestination(patrolDest);
			patrolCooldown = 5;
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
		PlayerStatsSingleton.instance.PlayerDamage(attackDamage);
	}


	void setAttackCooldown()
	{
		attackCooldown = 1 / attackSpeed;
	}
}
