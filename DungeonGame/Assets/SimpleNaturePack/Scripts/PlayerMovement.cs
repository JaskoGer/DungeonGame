using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float downForce;
    private Rigidbody playerRigidbody;
    private Vector3 change;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.z = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();

        RaycastHit hitInfo;
        float maxDistance = GetComponent<Collider>().bounds.extents.y - 0.8f;
        if(Physics.Raycast(transform.position, Vector3.down, out hitInfo))
        {
            if(hitInfo.distance > maxDistance)
            {
                playerRigidbody.AddForce(Vector3.down * downForce, ForceMode.Impulse);
            }
        }
    }

    public void MoveCharacter()
    {
        transform.Translate(change * speed * Time.deltaTime);
    }

    public void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
}
