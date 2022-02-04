using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed = 3f;
    void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            rb.AddForce(new Vector2(500f,100f));
        } 
        Debug.Log("Hited");
    }
 
}
