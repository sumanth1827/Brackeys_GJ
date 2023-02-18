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
    [SerializeField] private int waveno = 0;
   float wavetimer = 10f, spawntimer = 0f;
    [SerializeField] float spawnsettimer = 0.5f, wavesettimer = 10f;
    [SerializeField] Transform parentenemy;
    // Start is called before the first frame update
    void Start()
    {
        childloc = GetComponentsInChildren<Transform>()[1];
        wavetimer = 7f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveno < 4)
        {
            
            wavetimer += Time.deltaTime;

            if (wavetimer > wavesettimer)
            {
                spawned = true;
                wavetimer = 0f;
                waveno++;

            }
            if (spawned)
            {
                spawntimer += Time.deltaTime;
                if (spawntimer > spawnsettimer)
                {
                    spawned = false;

                    spawntimer = 0f;
                }
                if (spawntimer < spawnsettimer)
                {
                   
                    checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
                    if (checkrd)
                    {
                        Instantiate(enemies[0], childloc.position, enemies[0].transform.rotation, parentenemy);

                    }
                    else
                    {
                        Instantiate(enemies[0], transform.position, enemies[0].transform.rotation, parentenemy);
                    }

                }



            }
        }
        
    }
}
