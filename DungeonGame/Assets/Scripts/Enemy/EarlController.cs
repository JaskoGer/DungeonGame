using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

/**
 * @Author Jasko
 * bearbeitet von Kacper
 * Navigiert Earl
 */
public class EarlController : MonoBehaviour
{
    public Transform earlObj;
    private float changeX;
    private float changeY;
    private Vector3 lastPos;

    Transform target;
    Transform randyBody;
    UnityEngine.AI.NavMeshAgent agent;
    Animator earlAnim;

    void Start()
    {
        target = ObjectManager.instance.player.transform;
        randyBody = ObjectManager.instance.playerCharacter.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        earlAnim = GetComponentInChildren<Animator>();
        StartCoroutine(TrackLastPos());
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) >= 5f)
        {
            GoToPlayer();
        }
        SetAnimation();
    }

    /*
     * @Author Kacper Purtak
     * Setzt, je nach dem wie die Position von Earl ich aendert, die passende Animation
     */
    private void SetAnimation()
    {
        changeX = lastPos.x - earlObj.position.x;
        changeY = lastPos.y - earlObj.position.y;
        if (changeX < 0)
        {
            changeX = changeX * (-1);
        }
        if (changeY < 0)
        {
            changeY = changeY * (-1);
        }

        if (changeX < 0.1 && changeY < 0.1)
        {
            earlAnim.SetBool("isMoving", false);
        }
        else if (changeX > 0.1 || changeY > 0.1)
        {
            earlAnim.SetBool("isMoving", true);
        }
    }

    /*
     * @Author Kacper Purtak
     * Trackt jede Sekunde die Position von Earl
     */
    IEnumerator TrackLastPos()
    {
        while(1 != 0)
        {
            lastPos = earlObj.position;
            yield return new WaitForSeconds(0.5f);
        }
    }

    /**
     * @Author Jasko
     * Bestimmt wie Earl laufen muss
     */
    void GoToPlayer()
    {
        Vector3 dest = GetPosition();
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
        setSpeed(dest);
        agent.SetDestination(dest);
    }


    /**
     * @Author Jasko
     * Veraender die Geschwindigkeit von Earl abhängig von der Entfernung zum Spieler
     */
    void setSpeed(Vector3 dest)
    {
        double distance = Vector3.Distance(target.position, transform.position);
        if (distance < 10f)
        {
            agent.speed = 5f;
        }
        else if (distance < 20)
        {
            agent.speed = 10;
        }
        else
        {
            agent.speed = 20f;
        }
    }


    /**
     * @Author Jasko
     * Berechnet das neue Ziel für Earl
     */
    Vector3 GetPosition()
    {
        Vector3 playerPos = target.position;
        Vector3 playerRot = randyBody.eulerAngles;
        Vector3 dest =(Quaternion.Euler(playerRot) * Vector3.forward).normalized ;
        dest =  playerPos + Vector3.Scale(dest, new Vector3(-dest[2], 0, dest[0])).normalized * 3;
        return dest;
    }


}
