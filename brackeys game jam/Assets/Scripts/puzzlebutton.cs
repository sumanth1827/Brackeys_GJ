using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlebutton : MonoBehaviour
{
    
    public  int zero = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void up()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
        zero = 0;
    }
    public void down()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
        zero = 1;
    }
}
