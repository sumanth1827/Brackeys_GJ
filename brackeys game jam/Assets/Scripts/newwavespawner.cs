using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newwavespawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wavestarter());
    }

    // Update is called once per frame
    void Update()
    {
        if (i < enemy.Length)
        {


            if (enemy[i].transform.childCount == 0 && enemy[i].tag != "enemy")
            {
                //StopCoroutine(wavestarter());

                    Destroy(enemy[i]);
                
                
                i++;
                StartCoroutine(wavestarter());
            }
        }
    }
    IEnumerator wavestarter()
    {
        yield return null;
        if (i < enemy.Length)
        {


            if (i == 0)
            {
                enemy[i].SetActive(true);
            }
            else
            {
                yield return new WaitForSeconds(4f);
                enemy[i].SetActive(true);
                if (enemy[i].tag == "enemy")
                {
                    i++;
                    enemy[i].SetActive(true);
                }

            }
        }
        


    }
}
