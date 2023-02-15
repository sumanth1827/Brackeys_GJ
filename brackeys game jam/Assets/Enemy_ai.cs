using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyai : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed, checkradius, attackradius;
    public LayerMask player;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 move;
    private Vector2 dir; 
    //do follow with pathfinding

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
