using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip explodeSound, bulletHit, femZom, zomShot, assaultFire;
    static AudioSource audio;

    void Start()
    {
       
        explodeSound = Resources.Load<AudioClip>("BombBlast");
        bulletHit = Resources.Load<AudioClip>("bloodHit");
        femZom = Resources.Load<AudioClip>("femaleZombie");
        zomShot = Resources.Load<AudioClip>("zomGotShot");
        assaultFire = Resources.Load<AudioClip>("assaultNew"); 

        audio = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "blast":
                audio.PlayOneShot(explodeSound);
                break;
            case "hitSound":
                audio.PlayOneShot(bulletHit);
                break;
            case "zombieSound":
                audio.PlayOneShot(femZom);
                break;
            case "gotShotSound":
                audio.PlayOneShot(zomShot);
                break;
            case "fireAssault":
                audio.PlayOneShot(assaultFire);
                break;
        }

    }
}
