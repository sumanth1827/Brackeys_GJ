using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combination : MonoBehaviour
{
    //public bool zero1, zero2, zero3, zero4;
    //public bool[] puzzle;
    public  int[] sol;
    public Animator anim;
    public puzzlebutton a, b, c, d;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //NOTE: 1 is down, 0 is up
        if (a.zero == sol[0] && b.zero == sol[1] && c.zero == sol[2] && d.zero == sol[3])
        {
            anim.SetBool("open door", true);
        }
    }
}
