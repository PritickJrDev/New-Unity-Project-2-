using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultFire : MonoBehaviour
{
    //public SpriteRenderer assultGun;
    //private float rotZ;

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;

    float timeToFire = 0;
    Transform firePoint;

    public Transform bulletTrail;
    float spawnEffectTime = 0f;
    public float spawnEffectRate = 10f;

    public Transform muzzleFlash;
    public Transform hitEffect;

 
    AudioSource audioSource;
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError(" not fire point MEh");
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                CineShake.Instance.ShakeCamera(3f,.1f);
               
            }
        } 
        else
        {
            if(Input.GetButton("Fire1") && Time.time > timeToFire) {
                timeToFire = Time.time + 1/fireRate;
                Shoot();
                CineShake.Instance.ShakeCamera(3f, .1f);
                //SoundScript.PlaySound("fireAssault");
                audioSource.Play();

            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if(enemy != null)
            {
                enemy.TakeDamage(5);
                Debug.Log("we hit" + hit.collider.name + " and did " + damage + " damage");
            }
        }

        if(Time.time >= spawnEffectTime)
        {
            Vector3 hitPos;
            Vector3 hitNormal;

            if (hit.collider == null)
            {
                hitPos = (mousePosition - firePointPosition) * 30;
                hitNormal = new Vector3(9999, 9999, 9999);
            }
            else
            {
                hitPos = hit.point;
                hitNormal = hit.normal;
            }

            Effect(hitPos, hitNormal);
            spawnEffectTime = Time.time + 1 / spawnEffectRate;
        }
        
    }
    void Effect(Vector3 hitPos, Vector3 hitNormal)
    {
        Transform trail = Instantiate(bulletTrail, firePoint.position, firePoint.rotation);
        LineRenderer lr = trail.GetComponent<LineRenderer>();

        if (lr != null)
        {
            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, hitPos);
        }
        Destroy(trail.gameObject, 0.04f);

        if (hitNormal != new Vector3(9999, 9999, 9999))
        {
            Transform hitParticle = (Transform) Instantiate(hitEffect, hitPos, Quaternion.FromToRotation(Vector3.right, hitNormal));
            Destroy(hitParticle.gameObject, 1f);
        }
	
        Transform clone = (Transform) Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, 0f);
        Destroy(clone.gameObject, 0.2f); //Destroy clone particles
    }

}
