using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator anim;
    [SerializeField] GameObject sp1;
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
        if(collision.tag == "Player" && Input.GetKey("e"))
        {
           
            if(collision.GetComponent<Hunter>().haskey)
            {
                anim.SetBool("door1", true);
                collision.GetComponent<Hunter>().haskey = false;
            }
        }
    }
    void wavestarter()
    {
        Invoke("actualstarter", 4);
    }
    private void actualstarter()
    {
        sp1.SetActive(true);
    }
}
