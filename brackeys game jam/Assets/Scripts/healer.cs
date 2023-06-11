using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class healer : MonoBehaviour
{
    float healt = 0f;
    bool healmore = true;
    Animator i;
    
    // Start is called before the first frame update
    void Start()
    {
        i = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healt >= 200f)
        {
            healmore = false;
            i.Play("healsover");

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && healmore)
        {
            if (collision.GetComponent<Hunter>().health < collision.GetComponent<PlayerHealth>().totalHealth)
            {
                collision.GetComponent<Hunter>().health += 0.1f;
                healt += 0.1f;
            }
        }
    }
}
