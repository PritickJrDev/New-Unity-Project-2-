using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie3 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator anim;

    private bool isHurting, isDead, isAttacking;
    public float runSpeed=6;
    public int healthPoints = 3;
    public GameObject hitEffect;
    void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
        sr.GetComponent<SpriteRenderer>();
        anim.GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
       if(!isHurting && !isDead && !isAttacking)
        {
            Movement();
        }
      
    }

    void Update()
    {
       if(isAttacking)
        {
            anim.SetBool("attack", true);
        }
       else
        {
            anim.SetBool("attack", false);
        }
    }

    void Movement()
    {
        rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        
    }


    void OnTriggerEnter2D(Collider2D other) // for bullet trigger collider
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            healthPoints -= 1;
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            SoundScript.PlaySound("hitSound");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bullet") && healthPoints > 0)
        {
            SoundScript.PlaySound("zombieSound");
            anim.SetTrigger("hurt");
            StartCoroutine("Hurt");
        }
        else
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("dead");
            Destroy(gameObject, 2f);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && healthPoints > 0)
            {

                isAttacking = true;
                
            }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
            if (other.gameObject.CompareTag("Player") && healthPoints > 0)
            {

                isAttacking = false;
                
            }
    }
    
    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

       // rb.AddForce(new Vector2(300f, 0f));
        yield return new WaitForSeconds(2f);
        isHurting = false;
    }
}
