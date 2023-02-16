using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
    public float checkradius, attackradius, speed;
    public LayerMask player;
    public Transform pos;
    private Rigidbody2D rb;
    private bool checkrd, attackrd;
    private Vector2 move, dir;
    float t=0;
    public GameObject bullet;
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackradius, player);
        dir = pos.position - transform.position;
        dir.Normalize();
        move = dir;
        if(checkrd && !attackrd)
        {
           // rb.MovePosition((Vector2)transform.position + (move * speed * Time.deltaTime));
        }
        if(attackrd)
        {
            rb.velocity = Vector2.zero;
            t += Time.deltaTime;
            if(t>1)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                t = 0;
            }
             
        }
        if (health <= 0)
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
    }


}
