using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combination : MonoBehaviour
{
    //public bool zero1, zero2, zero3, zero4;
    //public bool[] puzzle;
    public  int[] sol;
    public Animator anim;
    //public puzzlebutton[] a, b, c, d;
    [SerializeField] private puzzlebutton[] a;
    [SerializeField] bool two, four, six; 
    // Start is called before the first frame update
    void Start()
    {


    }

    
    //NOTE: 1 is down, 0 is up
    void Update()
    {
        if(two)
        {
            if (a[0].zero == sol[0] && a[1].zero == sol[1])
            {
                anim.SetBool("open door", true);
            }
        }
        if(four)
        {
            if (a[0].zero == sol[0] && a[1].zero == sol[1] && a[2].zero == sol[2] && a[3].zero == sol[3])
            {
                anim.SetBool("open door", true);
            }
        }
        if(six)
        {
            if (a[0].zero == sol[0] && a[1].zero == sol[1] && a[2].zero == sol[2] && a[3].zero == sol[3] && a[4].zero == sol[4] && a[5].zero == sol[5])
            {
                anim.SetBool("open door", true);
            }
        }
        

    }
}
