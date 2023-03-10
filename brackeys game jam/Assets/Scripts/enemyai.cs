using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai : MonoBehaviour
{
    public float checkradius, attackradius, speed, knockback;
    public LayerMask player;
    private GameObject pos;
    private Rigidbody2D rb,rb2;
    private bool checkrd, attackrd;
    private Vector2 move, dir;
    private Animator anim;
    
    public bool key = false;
    public GameObject keys;
    private health h;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = GameObject.FindGameObjectWithTag("Player");
        rb2 = pos.GetComponent<Rigidbody2D>();
        h = GetComponent<health>();

        
    }

    // Update is called once per frame
    void Update()
    {
        checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackradius, player);
        anim.SetBool("Start", checkrd);
        anim.SetBool("Attack", attackrd);
        dir = pos.transform.position - transform.position;
        dir.Normalize();
        move = dir;
        anim.SetFloat("X", dir.x);
        anim.SetFloat("Y", dir.y);
        if(h.healths <=0)
        {
            if (key && keys != null)
            {
                Instantiate(keys, transform.position, keys.transform.rotation);
            }
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
    public void forcer()
    {
        rb2.AddForce(move * knockback, ForceMode2D.Impulse);
        pos.GetComponent<Hunter>().health -= 10;
       
    }
 
}
