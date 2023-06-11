using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

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

    public ParticleSystem muzzleFlash;
    public Transform shootingPoint;

    public AudioSource shootingSource;
    public AudioSource walkingSource;

    private float walkTime = 0;

    // special move references
    public int specialMoveTime = 5;
    public float specialFireRate = 5f;
    public float specialRotateSpeed = 5f;

    private float time = 0;
    private float specialFireTime = 0;

    public bool canSpecialMove = true;


    // states
    private bool normalState = true;
    private bool specialMoveState = false;

    public GameObject deathText;

    public GameObject black;

    public static Hunter instance;

    //health
    public float health = 100f;

    //key
    public bool haskey;
    public Transform button;

    public LayerMask tap;

    public GameObject dogPanel;

    private Animator anim;

    private float myTime = 0;
    private float fadeBlackTime = 5f;

    bool canEnd = false;

    private bool canFade = true;
    float balpha = 1;
    private void Start()
    {
        hunterRb = GetComponent<Rigidbody2D>();
        instance = this;
        anim = GetComponentInChildren<Animator>();

        shootingSource = GetComponent<AudioSource>();

        deathText.SetActive(false);

    }

    private void Update()
    {
        // for the camera shake;

        if(canFade)
        {
            myTime += Time.deltaTime;

            balpha = Mathf.Lerp(1,0,myTime/fadeBlackTime);
            
            black.GetComponent<CanvasGroup>().alpha = balpha;

            if(balpha == 0)
            {
                canFade = false;
                myTime = 0f;
            }
        }

        if(movement != Vector2.zero)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        // getting the inputs
        GetInput();

        // make the player face the mouse
        MouseFace();

        // Make the hunter move
        //HunterMovement();
        //die
        if (health <= 0)
        {
            //Destroy(gameObject);
            StartCoroutine(StartSceneAgain());
        }

        IEnumerator StartSceneAgain()
        {
            dogPanel.SetActive(true);
            deathText.SetActive(true);
            yield return new WaitForSecondsRealtime(5f);
             if(health<=0)
            {
                myTime += Time.deltaTime;
                if(myTime > fadeBlackTime)
                {
                    canEnd = true;
                    myTime = 0;
                }

                balpha = Mathf.Lerp(0,1,myTime/fadeBlackTime);
                black.GetComponent<CanvasGroup>().alpha = balpha;


                if(canEnd)
                    SceneManager.LoadScene(0);
            }
        }


        //check for door
        
        if (specialMoveState)
        {
            time += Time.deltaTime;

            if (time < specialMoveTime)
            {
                SpecialMoveState();
                muzzleFlash.Play();
            }

            else
            {
                time = 0;
                specialMoveState = false;
                normalState = true;
            }
        }

        if (Input.GetKeyDown("e"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)this.gameObject.transform.position, 8f, tap);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<puzzlebutton>().zero == 0)
                {
                    hit.collider.gameObject.GetComponent<puzzlebutton>().down();
                }
                else
                {
                    hit.collider.gameObject.GetComponent<puzzlebutton>().up();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        HunterMovement();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "key")
        {
            haskey = true;
            Destroy(collision.gameObject);
        }


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

        if (Input.GetMouseButtonDown(1) && normalState && canSpecialMove)
        {
            normalState = false;
            specialMoveState = true;

            ChiUpdate();
        }
    }

    // Code for  setting the player to face the direction of the mouse.
    private void MouseFace()
    {
            transform.up = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    // Code which updates the movement of the hunter
    private void HunterMovement()
    {
        // hunterRb.MovePosition((Vector2)this.transform.position + hunterSpeed * Time.fixedDeltaTime * movement.normalized);
        hunterRb.AddForce(movement.normalized * hunterSpeed* Time.fixedDeltaTime);

        if(movement.magnitude >0)
        {
            walkTime += Time.fixedDeltaTime;

            if (walkTime > 0.2f)
            {
                walkTime = 0;
                walkingSource.Play();
            }
        }
        
    }

    // Code which makes the hunter shoot normal bullets
    private void HunterShooting()
    {
        muzzleFlash.Play();
        shootingSource.Play();
        //CameraShaker.Instance.ShakeOnce(4f, 2f, 0.1f, 0.1f);
        GameObject bulletObject = Instantiate(gunBulletPrefab, shootingPoint.position, Quaternion.identity);
    }

    // Code to invoke the special move of the hunter
    private void SpecialMoveState()
    {
        specialFireTime += Time.deltaTime;
        if (specialFireTime > 1 / specialFireRate)
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.2f, 0.2f);
            shootingSource.Play();
            GameObject specialBulletObject = Instantiate(specialBulletPrefab, shootingPoint.position, Quaternion.identity);
            specialFireTime = 0;
        }

        //transform.Rotate(new Vector3(0f, 0f, specialRotateSpeed * Time.deltaTime));
    }

    private void ChiUpdate()
    {
        PlayerChi.instance.chiVal = 0;
    }
}
