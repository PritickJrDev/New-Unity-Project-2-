using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsHit : MonoBehaviour
{
   
    public GameObject hitEffect;
  
    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyHealth enem = col.GetComponent<EnemyHealth>();
        if (enem != null)
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Enemy1")) //enemy die in one shot
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            enem.TakeDamage(100);
            
        }

        if(col.gameObject.CompareTag("Enemy2"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);    
            enem.TakeDamage(50);
     
        }

    }

}
