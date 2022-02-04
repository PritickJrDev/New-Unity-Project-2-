using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeed : MonoBehaviour
{
    public float fireSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       // transform.Translate(Vector2.right * fireSpeed * Time.deltaTime, Space.Self); //use this when gameobject doesnt have RB attached
        
        rb.velocity = transform.right * fireSpeed; //use this when gameobject has rigidbody attached
        
        //adjustment of bullet rotating so that it moves in right angle
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
