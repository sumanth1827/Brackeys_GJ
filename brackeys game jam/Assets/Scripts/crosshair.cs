using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mousecursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousecursor;
    }
}
