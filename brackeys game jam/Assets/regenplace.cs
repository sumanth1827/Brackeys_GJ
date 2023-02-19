using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regenplace : MonoBehaviour
{
    
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
        if(collision.tag == "Player")
        {
            if(collision.GetComponent<Hunter>() != null)
            {
                if(collision.GetComponent<Hunter>().health <= 100)
                {
                    collision.GetComponent<Hunter>().health += 10;
                }
            }
            else
            {
                if (collision.GetComponent<Wizard>().health <= 100)
                {
                    collision.GetComponent<Wizard>().health += 10;
                }
            }
        }
    }
}
