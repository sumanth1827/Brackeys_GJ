using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterwave : MonoBehaviour
{
    [SerializeField] GameObject nextwave;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            timer += Time.deltaTime;
            if(timer >25)
            {
                nextwave.SetActive(true);
                Destroy(transform.parent);
            }

        }
    }
}
