using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator anim;
    //public GameObject deadEffect;

    private AudioSource hitSound;
    private bool isAttacking;
    void Start()
    {
        hitSound = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(isAttacking)
        {
            anim.SetTrigger("attack");

        }

    }
    void FixedUpdate()
    {
        if (isAttacking)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            anim.SetTrigger("dead");
            Die();
        }
        hitSound.Play();
        
    }
    void Die()
    {
        //Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject,1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && health > 0)
        {

            isAttacking = true;
        }
       
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && health > 0)
        {
            isAttacking = false;
        }
    }
}
