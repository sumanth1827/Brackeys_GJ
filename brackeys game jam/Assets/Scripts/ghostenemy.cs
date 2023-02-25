using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostenemy : MonoBehaviour
{
    public float checkradius, attackradius, speed,  knockback, attackradius2;
    private float actspeed;
    public LayerMask player;
    private GameObject pos;
    private Rigidbody2D rb, rb2;
    private bool checkrd, attackrd, attackrd2,attack = true,attack2 = false;
    private Vector2 move, dir;
    Color col, col2;
    private Animator anim;
    private float timer = 0f;
    private Collider2D collide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = GameObject.FindGameObjectWithTag("Player");
        rb2 = pos.GetComponent<Rigidbody2D>();
        col = GetComponent<SpriteRenderer>().material.color;
        col2 = new Color(col.r,col.g,col.b,1f);
        actspeed = speed;
        collide = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackradius, player);
        attackrd2 = Physics2D.OverlapCircle(transform.position, attackradius2, player);

        dir = pos.transform.position - transform.position;
        dir.Normalize();
        move = dir;
        if(attackrd && !attackrd2 && attack)
        {


            anim.SetBool("ghost", true);
            collide.enabled = true;
            //GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<SpriteRenderer>().material.color, col2,0.5f);
            //GetComponent<SpriteRenderer>().material.color = col2;
            //speed += 2f;
        }
        if(checkrd && !attackrd)
        {
            anim.SetBool("ghost", false);
            collide.enabled = false;

        }
        if (attack2)
        {
            timer += Time.deltaTime;
            if (timer < 4f)
            {
                attack = false;
            }
            else
            {
                attack = true;
                attack2 = false;
                anim.SetBool("ghost", false);
                collide.enabled = false;
                timer = 0f;
            }
        }

    }
    private void FixedUpdate()
    {
        if (checkrd && !attackrd2)
        {
            rb.MovePosition((Vector2)transform.position + (move * speed * Time.fixedDeltaTime));


        }
        if (attack)
        {
            
            if (attackrd2)
            {
                rb.velocity = Vector2.zero;
                rb2.AddForce(move * knockback, ForceMode2D.Impulse);
                pos.GetComponent<Hunter>().health -= 1f;
                attack2 = true;
                speed = actspeed;
                collide.enabled = false;
                Invoke("gone", 0.5f);



            }
            if (attackrd && !attackrd2)
            {
                speed += 2f;
            }
        }


    }
    void gone()
    {
        anim.SetBool("ghost", false);
    }
}
