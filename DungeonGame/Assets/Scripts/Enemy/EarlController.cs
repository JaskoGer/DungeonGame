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

    // Start is called before the first frame update
    void Start()
    {
        target = ObjectManager.instance.player.transform;
        randyBody = ObjectManager.instance.playerCharacter.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GoBehind();
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
        double distance = (dest.normalized - transform.position.normalized).magnitude;
        if (distance < 0.05f)
        {
            agent.speed = 5f;
        }
        else if (distance < 0.1)
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
        Vector3 dest = playerPos - (Quaternion.Euler(playerRot) * Vector3.forward) * 5;
        Debug.DrawRay(playerPos, -(Quaternion.Euler(playerRot) * Vector3.forward) * 5, Color.red, 0.1f);
        return dest;
    }


}
