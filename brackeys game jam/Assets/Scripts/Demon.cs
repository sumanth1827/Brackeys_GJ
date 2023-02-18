using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    // Player references
    private Rigidbody2D demonRb;

    // Hunter movement references
    private Vector2 movement;


    public float hunterSpeed = 5f;

    // Other gameobject references and variables
    public Vector2 mousePos;

    public Transform impactPoint;
    public float impactRadius = 10f;
    public LayerMask enemiesLayer;

    public ParticleSystem specialMoveParticles;

    // special move references
    public int specialMoveTime = 5;
    public float specialFireRate = 5f;
    public float specialRotateSpeed = 5f;
    public float specialMoveRadius = 5f;

    private float time = 0;
    private float specialFireTime = 0;


    // states
    private bool normalState = true;
    private bool specialMoveState = false;

    public static Demon instance;

    private void Start()
    {
        demonRb = GetComponent<Rigidbody2D>();
        instance = this;
        specialMoveParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        // getting the inputs
        GetInput();

        // make the player face the mouse
        MouseFace();

        // Make the Demon move
        DemonMovement();
    }

    void GetInput()
    {
        // setting the movement vector based on input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        // Click the mouse button to shoot
        if (Input.GetMouseButtonDown(0) && normalState)
            DemonHit();

        if (Input.GetKeyDown("l") && normalState)
        {
            Debug.Log("L pressed");
            SpecialMoveState();
        }
    }

    // Code for  setting the player to face the direction of the mouse.
    private void MouseFace()
    {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = mousePos - (Vector2)transform.position;
    }

    // Code which updates the movement of the Demon
    private void DemonMovement()
    {
        demonRb.MovePosition((Vector2)this.transform.position + hunterSpeed * Time.deltaTime * movement.normalized);
    }

    // Code which makes the hunter shoot normal bullets
    private void DemonHit()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(impactPoint.position, impactRadius, enemiesLayer);

        Debug.Log("Number of enemies affected by the attack: " + enemiesHit.Length);
    }

    // Code to invoke the special move of the Demon
    private void SpecialMoveState()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(this.transform.position, specialMoveRadius, enemiesLayer);
        Debug.Log(enemiesHit.Length);
        specialMoveParticles.Play();
    }

    private void OnDrawGizmosSelected()
    {
        if (impactPoint == null)
            return;

        Gizmos.DrawWireSphere(impactPoint.position, impactRadius);
    }
}
