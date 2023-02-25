using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    // Player references
    private Rigidbody2D wizardRb;

    // Wizard movement references
    private Vector2 movement;

    public float hunterSpeed = 3f;

    // Other gameobject references and variables
    public Vector2 mousePos;

    public GameObject wizardOrbPrefab;

    // special move references - wizard beam
    public int specialMoveTime = 3;
    public LineRenderer beam;
    public Transform beamStartPoint;
    public float beamTravelTime = 0.25f;
    public float farBeamTravelTime = 5f;

    [SerializeField] private float defaultBeamDistance = 0;
    private float time = 0;
    //animation
    private Animator anim;

    public LayerMask tap;

    // states
    private bool normalState = true;
    private bool specialMoveState = false;

    public static Wizard instance;
    public bool haskey = false;
    public float health = 100f;

    private float firerate = 0.5f;
    private bool canshoot = true;
    private void Start()
    {
        wizardRb = GetComponent<Rigidbody2D>();
        beam = GetComponent<LineRenderer>();
        instance = this;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            //Destroy(gameObject);
            Debug.Log("dead");
        }
        if (movement != Vector2.zero)
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
        anim.SetFloat("X", movement.normalized.x);
        anim.SetFloat("Y", movement.normalized.y);

        if (Input.GetKeyDown("e"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)this.gameObject.transform.position, 4f, tap);
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
        // getting the inputs
        GetInput();

        // make the player face the mouse
        MouseFace();

        // Make the Wizard move
        //WizardMovement();

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
                beam.enabled = false;
                specialMoveState = false;
                normalState = true;
            }
        }
    }
    private void FixedUpdate()
    {
        WizardMovement();
    }

    private void GetInput()
    {
        // setting the movement vector based on input


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        firerate += Time.deltaTime;
        if(firerate > 0.5f)
        {
            canshoot = true;
        }
        // Click the mouse button to shoot
        if (Input.GetMouseButtonDown(0) && normalState && canshoot)
        {
            

                WizardShooting();
                firerate = 0f;
            canshoot = false;
        
        }

        if (Input.GetKeyDown("l") && normalState)
        {
            normalState = false;
            specialMoveState = true;
        }
    }

    private void MouseFace()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - (Vector2)transform.position;
    }

    private void WizardMovement()
    {
        //wizardRb.MovePosition((Vector2)this.transform.position + hunterSpeed * Time.deltaTime * movement.normalized);
        wizardRb.AddForce(movement.normalized * hunterSpeed * Time.fixedDeltaTime);
       
    }

    void WizardShooting()
    {
        GameObject bulletObject = Instantiate(wizardOrbPrefab, beamStartPoint.position, Quaternion.identity);
    }

    private void SpecialMoveState()
    {
        beam.enabled = true;

        if (Physics2D.Raycast(transform.position, transform.up))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

            Vector2 finalPoint = Vector2.Lerp(beamStartPoint.position, hit.point, time/beamTravelTime);
            BeamRender(beamStartPoint.position, finalPoint);
        }

        else
        {
            Vector2 dir = (beamStartPoint.position - transform.position).normalized;

            Vector2 finalPoint = Vector2.Lerp(beamStartPoint.position, dir * defaultBeamDistance, time / farBeamTravelTime);
            BeamRender(beamStartPoint.position, dir * defaultBeamDistance);
        }

    }

    private void BeamRender(Vector2 startPosition, Vector2 endPosition)
    {
        beam.SetPosition(0,startPosition);

        beam.SetPosition(1,endPosition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "key")
        {
            haskey = true;
            Destroy(collision.gameObject);

        }

    }
}
