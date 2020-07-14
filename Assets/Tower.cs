using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan = null;
    [SerializeField] Transform targetToLook = null;

    private void Awake()
    {
        Vector3 adjustedHeight = new Vector3(0, 10, 0);
        targetToLook.position += adjustedHeight;
    }

    // Update is called once per frame
    void Update()
    {
        StareAtEnemy();
    }

    private void StareAtEnemy()
    {
        objectToPan.LookAt(targetToLook);
    }
}
