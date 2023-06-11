using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorafterwave : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Slider wavebar;
    
    
    // Start is called before the first frame update
    void Start()
    {

        wavebar.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {




        int[] kidcount = new int[transform.childCount];
        for (int i=1; i<= transform.childCount; i++)
        {
            kidcount[i-1] =  GetComponentsInChildren<Transform>()[i].childCount;
            
            

        }
        int sum = 0;
        foreach (int item in kidcount)
        {
            sum += item;
        }
        
        wavebar.value = sum;


        if (transform.childCount == 0)
        {
            anim.SetBool("open door", true);
            wavebar.gameObject.SetActive(false);
        }
    }

}
