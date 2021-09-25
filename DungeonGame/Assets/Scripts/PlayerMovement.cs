using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Cam;
    public Transform Player;
    public Transform PlayerCharacter;

    Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;

    public float speed = 7.0f;
    public float jumpSpeed = 7.0f;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        //Keyboard changes
        if (Math.Round(Cam.eulerAngles.y) == 0)
        {
            moveDirection = new Vector3(horizontal, 0.0f, vertical) * speed;
        }

        if (Math.Round(Cam.eulerAngles.y) == 90)
        {
            moveDirection = new Vector3(vertical, 0.0f, -horizontal) * speed;
        }

        if (Math.Round(Cam.eulerAngles.y) == 180)
        {
            moveDirection = new Vector3((-horizontal), 0.0f, -vertical) * speed;
        }

        if (Math.Round(Cam.eulerAngles.y) == 270)
        {
            moveDirection = new Vector3(-vertical, 0.0f, horizontal) * speed;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0f, jumpSpeed, 0f), ForceMode.Impulse);
            isGrounded = false;
        }

        //actual walking
        Player.Translate(moveDirection * Time.deltaTime);

        //player rotation
        if (moveDirection != Vector3.zero)
        {
            PlayerCharacter.rotation = Quaternion.Slerp(PlayerCharacter.rotation, Quaternion.LookRotation(moveDirection), 0.02F);
        }

    }
}
