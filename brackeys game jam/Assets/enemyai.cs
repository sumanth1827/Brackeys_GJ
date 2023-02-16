using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai : MonoBehaviour
{
    public float checkradius, attackradius, speed;
    public LayerMask player;
    public Transform pos;
    private Rigidbody2D rb;
    private bool checkrd, attackrd;
    private Vector2 move, dir;
    private Animator anim;
    public float health = 100f;
    public bool key = false;
    public GameObject keys;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackradius, player);
        anim.SetBool("Start", checkrd);
        anim.SetBool("Attack", attackrd);
        dir = pos.position - transform.position;
        dir.Normalize();
        move = dir;
        anim.SetFloat("X", dir.x);
        anim.SetFloat("Y", dir.y);
        if(health <=0)
        {
            Destroy(gameObject);
        }

    }
    private void FixedUpdate()
    {
        if (checkrd && !attackrd)
        {
            rb.MovePosition((Vector2)transform.position + (move * speed * Time.fixedDeltaTime));


        }
        if(attackrd)
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void OnDestroy()
    {
        if(key && keys!=null)
        {
            Instantiate(keys, transform.position, keys.transform.rotation);
        }
    }
}
