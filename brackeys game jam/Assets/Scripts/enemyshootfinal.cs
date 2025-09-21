using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshootfinal : MonoBehaviour
{
    // Start is called before the first frame update
    public float checkradius, attackradius, attackradius2, speed, knockback = 1000f;
    public LayerMask player;
    private Transform pos;
    private Rigidbody2D rb,rb2;
    private bool checkrd, attackrd,attackrd2;
    private Vector2 move, dir;
    private float actspeed;

    public GameObject bullet;
    private Animator anim;
    public float time = 1;
    float t,t2;
    private health h;
    [SerializeField] Animator anims;
    bool bigmama = true,runmama=false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2 = pos.GetComponent<Rigidbody2D>();
        t = time;
        anim = GetComponent<Animator>();
        h = GetComponent<health>();
        actspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("bigmama :" + bigmama);
        Debug.Log("runmama :" + runmama);
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
        attackrd2 = Physics2D.OverlapCircle(transform.position, attackradius2, player);
        dir = pos.position - transform.position;
        dir.Normalize();
        move = dir;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if(bigmama && attackrd)
        {
            runmama = false;
            StartCoroutine(bigboss());
            rb.velocity = Vector2.zero;
            anim.SetBool("walk", false);
            Instantiate(bullet, transform.position, Quaternion.identity);


        }
        if(runmama && attackrd)
        {
            bigmama = false;

            speed += 1f;
            if(!attackrd2)
            {
                rb.MovePosition((Vector2)transform.position + (move * speed * Time.fixedDeltaTime));
            }
            
            if (attackrd2)
            {
                rb.velocity = Vector2.zero;
                
                anim.SetBool("walk", false);
                rb2.AddForce(move * knockback, ForceMode2D.Impulse);
                pos.GetComponent<Hunter>().health -= 40f;
                runmama = false;
                StartCoroutine(bigbossrun());
                
                
            }

        }



    }
    IEnumerator bigboss()
    {
        yield return new WaitForSeconds(2f);
        bigmama = false;
        runmama = true;

    }
    IEnumerator bigbossrun()
    {
        speed = actspeed;
        
        yield return new WaitForSeconds(5f);
        bigmama = true;
        


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
