using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    Vector2 direction;

    public GameObject grenade;
    public float throwForce;
    public Transform throwPoint;

    //For trajectory display
    //public GameObject point;
    //GameObject[] points;
    //public int numberOfPoints;
    //public float spaceBtwPoints;

    //void Start()
    //{
    //    //trajectory
    //    points = new GameObject[numberOfPoints];
    //    for (int i = 0; i < numberOfPoints; i++)
    //    {
    //        points[i] = Instantiate(point, throwPoint.position, Quaternion.identity);
    //    }
    //}


    void Update()
    {
        Vector2 bombPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bombPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }

        //trajectory
        //for (int i = 0; i < numberOfPoints; i++)
        //{
        //    points[i].transform.position = AimPosition(i * spaceBtwPoints);
        //}
    }

    void ThrowGrenade()
    {
        GameObject obj = Instantiate(grenade, throwPoint.position, throwPoint.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = transform.right * throwForce;
        //Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        //AddForce(transform.right * throwForce, ForceMode2D.Force);
    }

    //For trajectory
    //Vector2 AimPosition(float t)
    //{
    //    Vector2 position = (Vector2)throwPoint.position + (direction.normalized * throwForce * t) * 0.5f * Physics2D.gravity * (t * t);
    //    return position;
    //}
}
