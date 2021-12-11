using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EarlController : MonoBehaviour
{
    Transform target;
    Transform randyBody;
    UnityEngine.AI.NavMeshAgent agent;
    Animator earlAnim;
    public Transform earlObj;
    [SerializeField] private float changeX;
    [SerializeField]private float changeY;
    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        target = ObjectManager.instance.player.transform;
        randyBody = ObjectManager.instance.playerCharacter.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        earlAnim = GetComponentInChildren<Animator>();
        StartCoroutine(TrackLastPos());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) >= 5f)
        {
            GoBehind();
        }
        else
        {
            agent.SetDestination(transform.position);
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
            yield return new WaitForSeconds(1f);
            Debug.Log("Letzte Position getrackt!");
        }
    }

    void GoBehind()
    {
        Vector3 dest = GetPosition();
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
        setSpeed(dest);
        agent.SetDestination(dest);
    }

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


    Vector3 GetPosition()
    {
        Vector3 playerPos = target.position;
        Vector3 playerRot = randyBody.eulerAngles;
        Vector3 dest = playerPos - (Quaternion.Euler(playerRot) * Vector3.forward) * 4;
        Debug.DrawRay(playerPos, -(Quaternion.Euler(playerRot) * Vector3.forward) * 4, Color.red, 0.1f);
        return dest;
    }


}
