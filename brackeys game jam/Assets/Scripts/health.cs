using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float healths = 100f, damageamt=10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healths <= 0)
        {

            Destroy(gameObject);
        }

    }
    public void damage()
    {
        healths -= damageamt;
    }
}
