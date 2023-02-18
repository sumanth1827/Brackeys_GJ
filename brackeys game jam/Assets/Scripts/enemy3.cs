using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public float speed;
    private GameObject pos;
    private Rigidbody2D rb,rb2;
    private Vector2 move, dir;
    
    private Animator anim;
    public float radius = 5.0f;
    public float power = 10.0f;
    public LayerMask player;
    public float checkrad = 17f, attackrad = 2f;
    private bool checkrd,attackrd ;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = GameObject.FindGameObjectWithTag("Player");
        rb2 = pos.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkrd = Physics2D.OverlapCircle(transform.position, checkrad, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackrad, player);
        dir = pos.transform.position - transform.position;
        dir.Normalize();
        move = dir;
        if(attackrd)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("exp", true);

        }
    }
    private void FixedUpdate()
    {
        if (!attackrd && checkrd)
        {
            rb.MovePosition((Vector2)transform.position + (move * speed * Time.fixedDeltaTime));
        }
    }

    public void explosion()
    {
        rb2.AddForce(power * move, ForceMode2D.Impulse);
        Destroy(gameObject);
    }

}
