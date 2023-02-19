using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlebutton : MonoBehaviour
{
    
    public  int zero = 0;
    public int jugad = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("aloo");
    }
    public void up()
    {
        if ( jugad == 0 )
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + 0.21f, transform.position.y - 0.21f);
        }
            zero = 0;
    }
    public void down()
    {
        if ( jugad == 0 )
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
        }
        else{
            transform.position = new Vector2(transform.position.x - 0.21f, transform.position.y + 0.21f);
        }
        
        zero = 1;
    }
}
