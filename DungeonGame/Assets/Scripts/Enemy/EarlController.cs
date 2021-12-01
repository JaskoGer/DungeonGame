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
        goBehind();
    }

    void goBehind()
    {
        Vector3 playerPos = target.position;
        Vector3 playerRot = randyBody.eulerAngles;
        Vector3 dest = playerPos - (Quaternion.Euler(playerRot) * Vector3.forward) * 5;
        Debug.DrawRay(playerPos, -(Quaternion.Euler(playerRot) * Vector3.forward) * 5, Color.red, 0.1f);
        Vector3 direction = (playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
        agent.SetDestination(dest);
    }
}
