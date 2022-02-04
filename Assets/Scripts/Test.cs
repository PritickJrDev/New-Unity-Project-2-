using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public delegate void CheckObject(string objName);
    public CheckObject objPointer;

    /*void OnEnable()
    {
        objPointer += GetName;
    }*/
    void Start()
    {
        objPointer = GetName;
        objPointer("testing");

        objPointer = GetNum;
        objPointer("One");
    }
    public void GetName(string objName)
    {
        Debug.Log("This is a string "+objName);
    }

    public void GetNum(string x)
    {
        Debug.Log("this is a number" + x);
    }
}
