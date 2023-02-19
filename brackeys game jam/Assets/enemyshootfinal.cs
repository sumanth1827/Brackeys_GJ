using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshootfinal : MonoBehaviour
{
    // Start is called before the first frame update
    public float checkradius, attackradius, speed;
    public LayerMask player;
    private Transform pos;
    private Rigidbody2D rb;
    private bool checkrd, attackrd;
    private Vector2 move, dir;

    public GameObject bullet, enemy,enemy2;
    private Animator anim;
    public float time = 1;
    float t,t2;
    private health h;
    [SerializeField] Animator anims;
    bool bigmama = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        t = time;
        anim = GetComponent<Animator>();
        h = GetComponent<health>();

    }

    // Update is called once per frame
    void Update()
    {
        if (h.healths < 5000f)
        {
            anim.SetBool("damage", true);
        }
        if(h.healths <= 40f)
        {
            anim.SetBool("death", true);
            anims.SetBool("last door", true);
        }


        checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackradius, player);
        dir = pos.position - transform.position;
        dir.Normalize();
        move = dir;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        t2 += Time.deltaTime;
        if(t2>15f)
        {
            bigmama = false;
        }
        if(t2>30f)
        {
            bigmama = true;
            t2 = 0f;
        }
        if (attackrd)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("walk", false);

            if (bigmama)
            {
                t += Time.deltaTime;
                if (t > 3f)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);

                }
                if (t > 6f)
                {
                    Instantiate(enemy, transform.position, Quaternion.identity);
                    t = 0;
                }
            }


        }

    }
    private void FixedUpdate()
    {
        if (checkrd && !attackrd)
        {
            rb.MovePosition((Vector2)transform.position + (move * speed * Time.fixedDeltaTime));
            anim.SetBool("walk", true);


        }
    }

}
