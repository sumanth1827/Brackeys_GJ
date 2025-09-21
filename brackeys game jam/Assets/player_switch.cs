using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_switch : MonoBehaviour
{
    public bool p1 = true, p2 = false;
    [SerializeField] GameObject hunters, wizzards;
    public static player_switch instance;
    public Slider hunterhealth, wizardhealth;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        hunterhealth.value = Hunter.instance.health / hunters.GetComponent<PlayerHealth>().totalHealth;
        if(Input.GetKeyDown("2") && p1)
        {
            wizzards.transform.position = hunters.transform.position;
            hunters.SetActive(false);
            wizzards.SetActive(true);
            camerafollow.instance.player = wizzards.GetComponent<Transform>();
            p1 = false;
            p2 = true;

        }
        if(Input.GetKeyDown("1") && p2)
        {
            hunters.transform.position = wizzards.transform.position;
            hunters.SetActive(true);
            wizzards.SetActive(false);
            camerafollow.instance.player = hunters.GetComponent<Transform>();
            p2 = false;
          p1 = true;
        }
        
    }
}
