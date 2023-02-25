using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float time = 0f;
    private float deathTime = 2f;

    private void Update()
    {
        time += Time.deltaTime;

        if(time >deathTime)
        {
            Destroy(this.gameObject);
        }

    }
}
