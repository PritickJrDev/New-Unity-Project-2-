using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Collider2D colObj;

    private bool isTrue;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    public LayerMask layer;
   
    void Start()
    {

        colObj = GetComponent<Collider2D>();
        StartCoroutine(Blast());
    }
   void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy1") || other.gameObject.CompareTag("Enemy2"))
        {
            colObj.isTrigger = false;
            isTrue = true;
            //Destroy(gameObject,3);
        }
        //if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        //{
        //    //Destroy(gameObject);
        //    isTrue = true;
        //}
    }

    IEnumerator Blast()
    {
        yield return new WaitForSeconds(3);
        if (isTrue)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            SoundScript.PlaySound("blast");
            // CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layer);

            foreach (Collider2D obj in colliders)
            { //all the collider game objects inside blast radius to be affected
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);

             //   blastDamage.TakeDamage(40);
            }

            Destroy(gameObject);
            isTrue = false;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
