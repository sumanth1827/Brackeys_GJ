using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChi : MonoBehaviour
{
    public float chiVal = 100;
    private float totalChi = 100;
    public float reloadChiTime = 15f;

    private float time = 0;

    public Slider chiSlider;

    public static PlayerChi instance;

    private void Start()
    {
        chiSlider.value = 1;
        instance = this;
    }

    private void Update()
    {
        chiSlider.value = chiVal / totalChi;

        if(chiVal <= 0)
        {
            Hunter.instance.canSpecialMove = false;
            time += Time.deltaTime;

            if(time > reloadChiTime)
            {
                time = 0;
                chiVal = 100;
                Hunter.instance.canSpecialMove = true;
            }
        }
    }
}
