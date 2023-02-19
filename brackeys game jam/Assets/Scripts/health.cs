using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float healths = 100f, damageamt=10f;
    // Start is called before the first frame update

    private GameObject bloodParticles;
    private AudioSource hitAudioManager;

    void Start()
    {
        hitAudioManager = GameObject.Find("AudioManagerHit").GetComponent<AudioSource>();
        bloodParticles = GameObject.Find("BloodParticles");
        bloodParticles.gameObject.transform.position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (healths <= 0)
        {
            hitAudioManager.Play();

            GameObject gb = Instantiate(bloodParticles, transform.position,Quaternion.identity);
            gb.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }

    public void damage()
    {
        healths -= damageamt;
    }
}
