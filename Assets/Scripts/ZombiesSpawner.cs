using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesSpawner : MonoBehaviour
{

    public GameObject[] zombies;
    private GameObject spawnedZombies;
    public Transform left, right;
    private int randomIndex;
    private int randomSide;

    public GameObject[] zombieGirls;
    private GameObject spawnedZombiesGirls;
    private int randomSide1;

    [SerializeField] AudioSource audioSource1;
    void Start()
    {
        audioSource1 = gameObject.GetComponent<AudioSource>();

        StartCoroutine(SpawnedZombies());
    }

    IEnumerator SpawnedZombies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));

            randomIndex = Random.Range(0, zombies.Length);
            spawnedZombies = Instantiate(zombies[randomIndex]);

            randomSide = Random.Range(0, 3);

            if (randomSide == 0)
            {
                spawnedZombies.transform.position = left.position;
                spawnedZombies.GetComponent<Zombies>().speed = Random.Range(1, 5); //moving right

                audioSource1.Play();
            }
            else 
            {
                spawnedZombies.transform.position = right.position;
                spawnedZombies.GetComponent<Zombies>().speed = -Random.Range(1, 5); //moving left
                spawnedZombies.transform.localScale = new Vector3(-1f, 1f, 1f); //scaling and flip monster in x-axis
                
            }

            //zombie 3 spawned
            randomSide1 = Random.Range(1, 10);

            if(randomSide1 == 2)
            {
                spawnedZombiesGirls = Instantiate(zombieGirls[0]);
                spawnedZombiesGirls.transform.position = left.position;
                spawnedZombiesGirls.GetComponent<Zombie3>().runSpeed = 6f;
                spawnedZombiesGirls.transform.localScale = new Vector3(1f, 1f, 1f);
                SoundScript.PlaySound("gotShotSound");

            }
            else if(randomSide1 == 9)
            {
                spawnedZombiesGirls = Instantiate(zombieGirls[0]);
                spawnedZombiesGirls.transform.position = right.position;
                spawnedZombiesGirls.GetComponent<Zombie3>().runSpeed = -6f;
                spawnedZombiesGirls.transform.localScale = new Vector3(-1f, 1f, 1f);
                SoundScript.PlaySound("gotShotSound");
            }

        }
    }
}
