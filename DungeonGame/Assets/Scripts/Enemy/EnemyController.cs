using System.Collections;
using static System.Console;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
/**
 * @author Jasko und Jonas
 * Erstellung der Klasse EnemyController und Deklarierung der Variablen
 */
public class EnemyController : MonoBehaviour
{
	public float lookRadius = 25f;
	public float attackDistance = 2f;
	public float movementSpeed = 5f;
	public float attackSpeed = 0.5f;
	public float attackDamage = 5f;
	public Vector3 patrolDest;
	public bool hasPatrolDest = false;
	public float enemyHP = 50;
	public float attackCooldown = 0f;
	private float patrolCooldown = 0f;
	//private float drawRayDuration = 0.2f;

	Transform target;
	NavMeshAgent agent;

	/**
	 * @author Jasko
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
	 * @author Jasko
	 * bearbeitet von TOBIAS und JONAS
	 *  Methode wird vor dem ersten Frame ausgeführt
	 */
	void Update()
	{
		// berechnet den Abstand zwischen dem Mob und dem Player
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
		if (HasVisual(distance))
		{
			agent.speed = movementSpeed;
			hasPatrolDest = false;
			ChasePlayer();
		}

		// wenn kein Player gefunden wird, wird die Patrolling Methode aufgerufen
		else
		{
			agent.speed = movementSpeed * 0.6f;
			Patrolling();
		}
	}


	/**
	 * @author Jasko
	 * überarbeitet und verbessert von JONAS
	 * Anpassung der Attacks durch TOBIAS
	 * Prüft ob ein Player in der Nähe ist und überprüft dann, ob nichts die Sicht des Mobs auf den Player blockiert
	 */
bool HasVisual(float distance)
	{
		RaycastHit hit;
		if (distance <= lookRadius)
		{
			//Deklarierung der Vektoren
			Quaternion qRaycastDir = Quaternion.LookRotation(target.position - transform.position);
			Vector3 raycastDir = qRaycastDir.eulerAngles;
			Vector3 addDegreeB = new Vector3(0, 1, 0);
			float angle = Quaternion.Angle(transform.rotation, qRaycastDir);
			float angleVision = Quaternion.Angle(qRaycastDir,transform.rotation);
			
			
			if (angleVision <= 90f || angleVision > 270f)
			{
				
				for (float j = 0; j < 10; j = j+1)
				{	
					for (int i = 0; i < 9; i++)
					{
						//Debug.DrawRay(transform.position, Quaternion.Euler(raycastDir + addDegreeB * i) * Vector3.forward * 10 + Vector3.up * j, Color.red, drawRayDuration, false);
						// prüft ob der Player direkt angeschaut wird, ob er in Angriffsreichweite ist und ob der Attack Cooldown <= 0 ist
						if (Physics.Raycast(transform.position, Quaternion.Euler(raycastDir + addDegreeB * i)  * Vector3.forward + Vector3.up * j, out hit, lookRadius))
						{
							 return CheckCollider(hit, distance);
						}
						if (Physics.Raycast(transform.position, Quaternion.Euler(raycastDir - addDegreeB * i) * Vector3.forward, out hit, lookRadius))
						{
							return CheckCollider(hit, distance);
						}
					}
				}
			
			}			
		}
		return false;
	}
	
	/**
	 * @author Jonas
	 * checkt ob das getroffene Ziel der Player oder ein anderes Objekt ist
	 */
	private bool CheckCollider(RaycastHit hit, float distance)
	{
		//print(hit.collider.name);
		if (hit.collider.name == "Player")
		{
			if (distance <= attackDistance && attackCooldown <= 0)
			{
				AttackInformation();
				SetAttackCooldown();
			}
			return true;
		}
		return true;
	}

	/**
	 * @author Jasko
	 * lässt das Mob auf random generierten Strecken patrouillieren, wenn kein Gegner bzw. Player in der Nähe ist
	 */
	private void Patrolling()
	{
		//prüft, ob das Mob einen aktiven Zielpunkt hat. Fall das nicht der Fall ist, wird ein neuer Punkt zugewiesen
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

	/**
	 * @author Jasko
	 * lässt das Mob den Player verfolgen, wenn er in der unmittelbaren Nähe ist
	 */
	private void ChasePlayer()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = lookRotation;
		agent.SetDestination(target.position);
	}

	/**
	 * @author Jasko
	 * benachrichtigt den Spieler, dass er angegriffen wird
	 */
	void AttackInformation()
	{
		print("I punched you in the face you A-hole!");
		PlayerStatsSingleton.instance.PlayerDamage(attackDamage);
	}

	/**
	 * @author Tobias
	 * setzt den Attack Cooldown
	 */
	void SetAttackCooldown()
	{
		attackCooldown = 1 / attackSpeed;
	}

	/**
	 * @author Tobias
	 * getDamage
	 */
	public void GetDamage(float pAttackDamage)
	{
		enemyHP -= pAttackDamage;
		if (enemyHP <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
