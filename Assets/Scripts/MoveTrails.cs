using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrails : MonoBehaviour
{
    public int trailSpeed = 230;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * trailSpeed);
        Destroy(gameObject, 1);
    }
}
