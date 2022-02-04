using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolDamage : MonoBehaviour
{
    public GameObject hitEffect;
    void OnTriggerEnter2D(Collider2D collide)
    {
        EnemyHealth enem = collide.GetComponent<EnemyHealth>();
            if (enem != null)
            {
                Destroy(gameObject);
            }

            if (collide.gameObject.CompareTag("Enemy1")) 
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                enem.TakeDamage(50); 
            }

            if (collide.gameObject.CompareTag("Enemy2"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                enem.TakeDamage(30); 
            }
    }
}
