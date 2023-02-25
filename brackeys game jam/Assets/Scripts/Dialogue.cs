using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public List<GameObject> dogs = new List<GameObject>();

    private GameObject panel;

    void Start()
    {
        panel = this.gameObject;

        dogs[0].SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown("z"))
        {
            if(dogs[0].activeInHierarchy)
            {
                dogs[0].SetActive(false);
                dogs[1].SetActive(true);
            }

            else if(dogs[1].activeInHierarchy)
            {
                dogs[1].SetActive(false);
                dogs[2].SetActive(true);
            }

            else
            {
                dogs[2].SetActive(false);
                panel.SetActive(false);
            }
        }
    }
    
}
