using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey("e"))
        {

            if (collision.GetComponent<Wizard>().haskey)
            {
                anim.SetBool("door1", true);
                collision.GetComponent<Wizard>().haskey = false;
            }
        }
    }
}
