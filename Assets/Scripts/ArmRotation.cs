using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public int rotationOffset = 90;
    public AudioSource audioSource;

    //Code for shotgun
    public GameObject bullet;
    public Transform aimRotation;
    public SpriteRenderer Gun;
    public GameObject shotEffect;
    private float shotTime;
    private float shotInterval = 1f;
    private bool shotgunActive;
    GameObject weapon1;
    public AudioClip shotgunFireSound;

    //Code for pistol
    public GameObject pistolBullet;
    public Transform pistolAim;
    public SpriteRenderer pistolGun;
    public GameObject pistolShotEffect;
    private float pistolShotTime;
    private float pistolShotInterval = .5f;
    private bool pistolActive;
    GameObject weapon2;
    public AudioClip pistolFireSound;

    //code for assult
    private bool assultActive;
    GameObject weapon3;

    void Awake()
    {
        weapon1 = GameObject.Find("Shotgun");
        weapon2 = GameObject.Find("Pistol");
        weapon3 = GameObject.Find("Assault");
    }
    void Start()
    {
        // audioSource = gameObject.GetComponent<AudioSource>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSource = audioSources[0];
        shotgunFireSound = audioSources[0].clip;
        pistolFireSound = audioSources[1].clip;

        Gun.GetComponent<SpriteRenderer>();
        pistolGun.GetComponent<SpriteRenderer>();

        weapon1.SetActive(false);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
    }


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

        if (rotZ < -90f || rotZ > 90f)
        {
            Gun.flipY = true;
            pistolGun.flipY = true;
        }
        else if (rotZ < 90f && rotZ > -90f)
        {
            Gun.flipY = false;
            pistolGun.flipY = false;
        }

        //Firing gun
        if (Input.GetMouseButtonDown(0) && Time.time>shotTime && shotgunActive) //shotgun fire
        {
            audioSource.PlayOneShot(shotgunFireSound);
            Shooting();
            shotTime = Time.time + shotInterval;
        }

        if(Input.GetMouseButtonDown(0) && Time.time>pistolShotTime  && pistolActive) //pistol Fire
        {
            audioSource.PlayOneShot(pistolFireSound);
            ShootingPistol();
            pistolShotTime = Time.time + pistolShotInterval;
        }

        FindWeapon();
    }

    private void Shooting()
    {
            
            GameObject shoot = Instantiate(bullet, aimRotation.transform.position, aimRotation.transform.rotation);
            Instantiate(shotEffect, aimRotation.position, Quaternion.identity);
            Destroy(shoot, .3f);
        
    }

    private void ShootingPistol()
    {
        GameObject shoot = Instantiate(pistolBullet, pistolAim.transform.position, pistolAim.transform.rotation);
        Instantiate(shotEffect, pistolAim.position, Quaternion.identity);
        Destroy(shoot, 0.6f);
    }

    private void FindWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon2.SetActive(true);
            pistolActive = true;

            weapon1.SetActive(false);
            shotgunActive = false;

            weapon3.SetActive(false);
            assultActive = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1.SetActive(true);
            shotgunActive = true;

            weapon2.SetActive(false);
            pistolActive = false;

            weapon3.SetActive(false);
            assultActive = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon3.SetActive(true);
            assultActive = true;

            weapon2.SetActive(false);
            pistolActive = false;

            weapon1.SetActive(false);
            shotgunActive = false;
        }
       
    }
}
