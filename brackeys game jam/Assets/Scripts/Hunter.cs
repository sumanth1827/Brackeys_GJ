using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    // Player references
    private Rigidbody2D hunterRb;

    // Hunter movement references
    private Vector2 movement;


    public float hunterSpeed = 5f;

    // Other gameobject references and variables
    public Vector2 mousePos;

    public GameObject gunBulletPrefab;
    public GameObject specialBulletPrefab;

    // special move references
    public int specialMoveTime = 5;
    public float specialFireRate = 5f;
    public float specialRotateSpeed = 5f;

    private float time = 0;
    private float specialFireTime = 0;


    // states
    private bool normalState = true;
    private bool specialMoveState = false;

    public static Hunter instance;


    private void Start()
    {
        hunterRb = GetComponent<Rigidbody2D>();
        instance = this;
    }

    private void Update()
    {
        // getting the inputs
        GetInput();

        // make the player face the mouse
        MouseFace();

        // Make the hunter move
        //HunterMovement();

        if (specialMoveState)
        {
            time += Time.deltaTime;

            if (time < specialMoveTime)
            {
                SpecialMoveState();
            }

            else
            {
                time = 0;
                specialMoveState = false;
                normalState = true;
            }
        }
    }

    private void FixedUpdate()
    {
        HunterMovement();
    }

    void GetInput()
    {
        // setting the movement vector based on input

        if (normalState)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        else if (specialMoveState)
            movement = new Vector2(0f, 0f);

        // Click the mouse button to shoot
        if (Input.GetMouseButtonDown(0))
            HunterShooting();

        if (Input.GetKeyDown("l") && normalState)
        {
            normalState = false;
            specialMoveState = true;
        }
    }

    // Code for  setting the player to face the direction of the mouse.
    private void MouseFace()
    {
        if (normalState)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = mousePos - (Vector2)transform.position;
        }
    }

    // Code which updates the movement of the hunter
    private void HunterMovement()
    {
        hunterRb.MovePosition((Vector2)this.transform.position + hunterSpeed * Time.fixedDeltaTime * movement.normalized);
    }

    // Code which makes the hunter shoot normal bullets
    private void HunterShooting()
    {
        GameObject bulletObject = Instantiate(gunBulletPrefab, transform.position, Quaternion.identity);
    }

    // Code to invoke the special move of the hunter
    private void SpecialMoveState()
    {
        specialFireTime += Time.deltaTime;
        if (specialFireTime > 1 / specialFireRate)
        {
            GameObject specialBulletObject = Instantiate(specialBulletPrefab, transform.position, Quaternion.identity);
            specialFireTime = 0;
        }

        transform.Rotate(new Vector3(0f, 0f, specialRotateSpeed * Time.deltaTime));
    }
}
