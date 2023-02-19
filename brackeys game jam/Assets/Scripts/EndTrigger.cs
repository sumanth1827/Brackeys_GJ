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
            Debug.Log("entered trigger");

            panel.SetActive(true);
            dog.SetActive(true);

            StartCoroutine(timedelay());
        }
    }

    IEnumerator timedelay()
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(1);
    }
}
