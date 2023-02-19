using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    private float totalHealth = 100;

    // references

    public Slider healthSlider;

    public static PlayerHealth instance;

    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        healthSlider.value = health / totalHealth;
    }
}
