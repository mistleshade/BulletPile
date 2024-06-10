using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePooledObject : MonoBehaviour
{
    public bool isUsing;
    // Use this for initialization
    virtual public void Init(GameObject g)
    {

    }
    virtual public void SetActive_Pool(bool a)
    {

    }
    public void NonActive()
    {
        isUsing = false;
        gameObject.SetActive(false);
    }
}