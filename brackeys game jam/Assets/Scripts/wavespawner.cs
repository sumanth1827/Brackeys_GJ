using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] LayerMask player;
    bool checkrd;
    bool spawned;
    float checkradius = 20f;
    Transform childloc;
    float wavetimer = 10f, spawntimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        childloc = GetComponentsInChildren<Transform>()[1];
        wavetimer = 10f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        wavetimer += Time.deltaTime;
        if (wavetimer > 10)
        {
            spawned = true;
            wavetimer = 0f;
            
        }
        if(spawned)
        {
            spawntimer += Time.deltaTime;
            if(spawntimer>1)
            {
                spawned = false;
                spawntimer = 0f;
            }
            if (spawntimer < 1)
            {
                Debug.Log("now1");
                checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
                if (checkrd)
                {
                    Instantiate(enemies[0], childloc.position, enemies[0].transform.rotation);

                }
                else
                {
                    Instantiate(enemies[0], transform.position, enemies[0].transform.rotation);
                }

            }
            
            
        }
        
        
    }
}
