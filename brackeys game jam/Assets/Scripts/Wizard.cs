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
    


    // states
    private bool normalState = true;
    private bool specialMoveState = false;

    public static Wizard instance;

    private void Start()
    {
        wizardRb = GetComponent<Rigidbody2D>();
        beam = GetComponent<LineRenderer>();
        instance = this;
    }

    private void Update()
    {
        // getting the inputs
        GetInput();

        // make the player face the mouse
        MouseFace();

        // Make the hunter move
        WizardMovement();

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

    private void GetInput()
    {
        // setting the movement vector based on input


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        // Click the mouse button to shoot
        if (Input.GetMouseButtonDown(0) && normalState)
            WizardShooting();

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
        wizardRb.MovePosition((Vector2)this.transform.position + hunterSpeed * Time.deltaTime * movement.normalized);
    }

    void WizardShooting()
    {
        GameObject bulletObject = Instantiate(wizardOrbPrefab, transform.position, Quaternion.identity);
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
}
