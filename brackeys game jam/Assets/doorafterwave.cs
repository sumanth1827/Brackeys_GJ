using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorafterwave : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            anim.SetBool("open door", true);
        }
    }
}
