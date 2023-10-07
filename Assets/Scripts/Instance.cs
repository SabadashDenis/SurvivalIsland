using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Instance : MonoBehaviour
{
    protected bool isActive = false;
    
    private void Awake()
    {
        Init();
    }
    
    private void Start()
    {
        Activate(true);
    }

    protected abstract void Init();

    protected virtual void Activate(bool condition)
    {
        isActive = condition;
        gameObject.SetActive(condition);
    }
}
