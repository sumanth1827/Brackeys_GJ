using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
    public float checkradius, attackradius, speed;
    public LayerMask player;
    private Transform pos;
    private Rigidbody2D rb;
    private bool checkrd, attackrd;
    private Vector2 move, dir;
    
    public GameObject bullet;
    
    public float time = 1;
    float t;

    private Animator anim1,anim2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        t = time;

            anim1 = GetComponentsInChildren<Animator>()[0];
            anim2 = GetComponentsInChildren<Animator>()[1];

    }

    // Update is called once per frame
    void Update()
    {
        checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackradius, player);
        dir = pos.position - transform.position;
        dir.Normalize();
        move = dir;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z );
        if (checkrd && !attackrd)
        {
           // rb.MovePosition((Vector2)transform.position + (move * speed * Time.deltaTime));
        }
        if(attackrd)
        {
            rb.velocity = Vector2.zero;

                anim1.SetBool("walking", false);
                anim2.SetBool("walking", false);

            t += Time.deltaTime;
            if(t>time)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                t = 0;
            }
             
        }

    }
    private void FixedUpdate()
    {
        if (checkrd && !attackrd)
        {
            rb.MovePosition((Vector2)transform.position + (move * speed * Time.fixedDeltaTime));
            anim1.SetBool("walking", true);
            anim2.SetBool("walking", true);

        }
    }


}
