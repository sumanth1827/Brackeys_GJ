using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    private bool trapped = false;
    private GameObject p;
    float t = 0;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trapped)
        {
            
            p.transform.position = new Vector2(transform.position.x, transform.position.y+0.6f);
            
            t += Time.deltaTime;
            if(t>4)
            {
                
                trapped = false;
                Destroy(gameObject);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            trapped = true;
            p = collision.gameObject;
            anim.SetBool("bear", true);
            

        }
    }
}
