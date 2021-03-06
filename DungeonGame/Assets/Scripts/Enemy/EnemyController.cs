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
 * Bearbeitet von Tobias
 */
public class EnemyController : MonoBehaviour
{
	private float lookRadius = 25f;
	[SerializeField]
	private float attackDistance = 2f;
	private float movementSpeed = 5f;
	private float attackSpeed = 0.5f;
	[SerializeField]
	private float attackDamage = 5f;
	public Vector3 patrolDest;
	public bool hasPatrolDest = false;
	[SerializeField]
	private float enemyHP = 50;
	private float attackCooldown = 0f;
	private float patrolCooldown = 0f;
	[SerializeField]
	private Renderer enemyRend;
	[SerializeField]
	private Material rimuruNormal;
	[SerializeField]
	private Material rimuruDamage;
	Animator animator;
	private Rigidbody rg;
    private Vector3 lastPosition;

	Transform target;
	NavMeshAgent agent;


	/**
	 * @author Jasko
	 * Methode Start() wird vor dem ersten geladenen Bild aufgerufen
	 * setzt die Attribute für das Mob
	 */
	void Start()
	{
		rg = GetComponent<Rigidbody>();
		animator = GetComponentInChildren<Animator>();
		target = ObjectManager.instance.player.transform;

		// setzen der Attribute für den agent
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.stoppingDistance = attackDistance - 0.2f;
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

		SetAnimation();
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
			if (distance <= lookRadius * 0.3)
			{
				if (distance <= attackDistance && attackCooldown <= 0)
				{
					StartCoroutine(AttackPlayer());
					SetAttackCooldown();
				}
				return true;
            }
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
		if (hit.collider.name == "Player")
		{
			if (distance <= attackDistance && attackCooldown <= 0)
			{
				StartCoroutine(AttackPlayer());
				SetAttackCooldown();
			}
			return true;
		}
		return true;
	}

	/**
	 * @author Jasko
	 * lässt das Mob auf random generierten Strecken patrouillieren, wenn kein Player im Sichtfeld ist
	 */
	private void Patrolling()
	{
		//prüft, ob das Mob einen aktiven Zielpunkt hat. Falls das nicht der Fall ist, wird ein neuer Punkt zugewiesen
		if (!hasPatrolDest || Vector3.Distance(patrolDest, transform.position) >= 14f)
		{
			NavMeshHit hit;
			patrolDest = new Vector3(transform.position[0] + Random.Range(-10f, 10), transform.position[1], transform.position[2] + Random.Range(-10, 10));
			hasPatrolDest = NavMesh.SamplePosition(patrolDest, out hit, 10, NavMesh.AllAreas);
			patrolDest = hit.position;
		}

		else if (Vector3.Distance(patrolDest, transform.position) <= 2f)
		{
			hasPatrolDest = false;
			patrolCooldown = 3;
		}

		else
		{
			Vector3 direction = (patrolDest - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
			transform.rotation = lookRotation;
			agent.SetDestination(patrolDest);
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
	 * @author Tobias
	 * benachrichtigt den Spieler, dass er angegriffen wird
	 */
	IEnumerator AttackPlayer()
	{
		animator.SetBool("isAttacking", true);
		yield return new WaitForSeconds(0.6f);
		PlayerStatsSingleton.instance.PlayerDamage(attackDamage);
		animator.SetBool("isAttacking", false);
	}

	/*
     * @Author Tobias Haubold
     * Setzt die movement variable des enemies durch Postionsveränderung
     */
	private void SetAnimation()
	{
		float distance = Vector3.Distance(lastPosition, transform.position);
		
		if (distance < 0.1f)
		{
			animator.SetBool("isMoving", false);
		}
		else if (distance > 0.1f)
		{
			animator.SetBool("isMoving", true);
        }
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
		rg.AddForce(ObjectManager.instance.playerCharacter.transform.rotation * new Vector3(0, 2.5f, 5f), ForceMode.Impulse);
		StartCoroutine(EnemyAttackColor());
		attackCooldown = 1f;
		if (enemyHP <= 0)
		{
			PlayerStatsSingleton.instance.AddPlayerXp(40);
			PlayerStatsSingleton.instance.AddPlayerMoneten(20);
			BossSpawn.instance.addEnemies(-1);
			Destroy(this.gameObject);
		}
	}


	/**
	 * @author Tobias
	 * Damage Feedback
	 */
	IEnumerator EnemyAttackColor()
    {
		enemyRend.material = rimuruDamage;
		yield return new WaitForSeconds(0.5f);
		enemyRend.material = rimuruNormal;
	}

	/**
	 * @author Tobias
	 * setHealth
	 */
	public void setHealth(float pHp)
    {
		enemyHP = pHp;
    }

	/**
	 * @author Tobias
	 * setDamage
	 */
	public void setAttackDamage(float pAD)
	{
		attackDamage = pAD;
	}
}
