using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player;
    public static camerafollow instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
