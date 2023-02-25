using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    public GameObject panel;
    public GameObject dog;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            panel.SetActive(true);
            dog.SetActive(true);

            StartCoroutine(delay());
        }


    }

    IEnumerator delay()
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(0);
    }
}
