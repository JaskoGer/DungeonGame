using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * @Author Tobias
 * @Since 22.09.2021
 * Script für die Steuerung des Characters
 */

public class PlayerMovement : MonoBehaviour
{
    private Transform cam;
    private Transform player;
    private Transform playerCharacter;
    Animator animator;

    Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveDir = Vector3.zero;
    private float moveDirMag;

    public static PlayerMovement instance = null;

    public float normalSpeed = 7.0f;
    public float speed = 7.0f;
    public float jumpForce = 5.0f;
    public float gravityScale = 1.3f;
    public bool isGrounded = false;
    public bool died = false;
    float lerpSpeed = 7.5f;
    float jumpCooldown = 0;

    bool wallTrigger = false;

    RaycastHit hitEnemy1;
    RaycastHit hitEnemy2;
    RaycastHit hitEnemy3;

    private void Awake()
    {
        // Erstellen der Instance dieser Klasse
        if (instance == null)
        {
            instance = this;
        }
        //Zerstöre ein bestehendes Objekt, falls es nicht dieses ist
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /**
     * @Author Tobias
     * auszuführende Methode beim Spielstart
     */
    void Start()
    {
        cam = ObjectManager.instance.camRotator.transform;
        playerCharacter = ObjectManager.instance.playerCharacter.transform;
        player = ObjectManager.instance.player.transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        wallTrigger = true;
    }

    /**
     * @Author Tobias
     * Abfrage aller Raycasts zum Boden und restliche Physics
     */
    void FixedUpdate()
    {
        // Verlangsamung falls in der Luft (imitierte Reibung)
        moveDirection = 0.99f * moveDirection;

        // Gravitation
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);

        //Raycasts zum überprüfen der Postition
        if (Physics.Raycast(playerCharacter.position + Vector3.up * 0.5f, Vector3.down, 1f))
        {
            isGrounded = true;
        }
        else if (Physics.Raycast(playerCharacter.position + Vector3.up * 0.5f + Vector3.forward * 0.5f + Vector3.left * 0.5f, Vector3.down, 1f))
        {
            isGrounded = true;
        }
        else if (Physics.Raycast(playerCharacter.position + Vector3.up * 0.5f + Vector3.forward * 0.5f + Vector3.right * 0.5f, Vector3.down, 1f))
        {
            isGrounded = true;
        }
        else if (Physics.Raycast(playerCharacter.position + Vector3.up * 0.5f + Vector3.back * 0.5f + Vector3.left * 0.5f, Vector3.down, 1f))
        {
            isGrounded = true;
        }
        else if (Physics.Raycast(playerCharacter.position + Vector3.up * 0.5f + Vector3.back * 0.5f + Vector3.right * 0.5f, Vector3.down, 1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Raycast zum Angreifen nach vorne
        Physics.Raycast(playerCharacter.position + new Vector3(0, 0.3f, 0), (playerCharacter.rotation) * Vector3.forward, out hitEnemy1, PlayerStatsSingleton.instance.GetAttackRange());
        //Raycast zum Angreifen nach 3° nach rechts
        Physics.Raycast(playerCharacter.position + new Vector3(0, 0.3f, 0), (playerCharacter.rotation * Quaternion.Euler(Vector3.up * 5)) * Vector3.forward, out hitEnemy2, PlayerStatsSingleton.instance.GetAttackRange());
        //Raycast zum Angreifen nach 3° nach links
        Physics.Raycast(playerCharacter.position + new Vector3(0, 0.3f, 0), (playerCharacter.rotation * Quaternion.Euler(Vector3.down * 5)) * Vector3.forward, out hitEnemy3, PlayerStatsSingleton.instance.GetAttackRange());
    }

    /**
     * @Author Tobias
     * Steuerung des Characters mit Inputs
     */
    void Update()
    {
        if (!died)
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            //sprinting
            if (isGrounded)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = 11.0f;
                    animator.SetFloat("speed", speed / 8.0f);
                }
                else
                {
                    speed = normalSpeed;
                    animator.SetFloat("speed", 1.0f);
                }
            }

            if (!isGrounded)
            {
                animator.SetFloat("speed", 0.0f);
            }


            //Springen
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpCooldown <= 0)
            {
                jumpCooldown = 0.6f;
                rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
                isGrounded = false;
            }


            //Tastenänderungen beim Drehen der Kamera
            moveDir = Vector3.zero;
            moveDirMag = (moveDirection).magnitude;
            if (Math.Round(cam.eulerAngles.y) == 0)
            {
                moveDir = new Vector3(horizontal, 0.0f, vertical).normalized;
            }

            if (Math.Round(cam.eulerAngles.y) == 90)
            {
                moveDir = new Vector3(vertical, 0.0f, -horizontal).normalized;
            }

            if (Math.Round(cam.eulerAngles.y) == 180)
            {
                moveDir = new Vector3((-horizontal), 0.0f, -vertical).normalized;
            }

            if (Math.Round(cam.eulerAngles.y) == 270)
            {
                moveDir = new Vector3(-vertical, 0.0f, horizontal).normalized;
            }

            if (isGrounded)
            {
                moveDirection = moveDir;
            }
            else
            {
                if (moveDir != Vector3.zero)
                {
                    moveDirection = moveDir.normalized * moveDirMag;
                }
            }

            //Spielerpositionsändreung mit translate

            if (wallTrigger)
            {
                rb.velocity = Vector3.zero;
                moveDirection = Vector3.zero;
                wallTrigger = false;
            }

            if (!animator.GetBool("attack"))
            {
                //rb.MovePosition(transform.position + moveDirection * speed / 50);
                player.Translate(moveDirection * Time.deltaTime * speed);
            }

            //Spielerdrehung mit schönem Übergang
            if (moveDirection != Vector3.zero)
            {
                playerCharacter.rotation = Quaternion.Slerp(playerCharacter.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * lerpSpeed);
            }

            //Boolean als bool für die Laufanimation des Spielers
            if (moveDirection != Vector3.zero)
            {
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }

            //emote (H) : T-Pose
            if (Input.GetKey(KeyCode.H))
            {
                animator.SetBool("EmoteT", true);
            }
            else
            {
                animator.SetBool("EmoteT", false);
            }

            //spring Cooldown, damit er nicht fliegt
            if (jumpCooldown > 0)
            {
                jumpCooldown -= Time.deltaTime;
            }

            /**
             * angreifen
             * bearbeitet von Kacper
             */
            if (!EventSystem.current.IsPointerOverGameObject() && (Input.GetButton("Fire1") && FirstSceneComplete.isStarterWeaponPickedUp == true || Input.GetButton("Fire1") && GlobalScene.currentScene > 2))
            {
                if (ObjectManager.instance.metalFork.activeSelf || ObjectManager.instance.pitchFork.activeSelf)
                {
                    if (animator.GetBool("attack") == false)
                    {
                        animator.SetBool("attack", true);
                        StartCoroutine(AttackAnimation());
                    }
                }

            }
        }
    }

    /**
     * @Author Kacper
     * Methode zum Abspielen der Angriffsanimation
     * bearbeitet von Tobias
     */
    IEnumerator AttackAnimation()
    {
        animator.SetBool("moving", false);
        yield return new WaitForSeconds(0.3f);
        PlayerStatsSingleton.instance.AttackEnemy(hitEnemy1, hitEnemy2, hitEnemy3);
        yield return new WaitForSeconds(0.45f);
        animator.SetBool("attack", false);
    }
}
