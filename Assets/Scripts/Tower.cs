using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan = null;
    [SerializeField] Transform targetToLook = null;
    private ParticleSystem bullets;

    [SerializeField] float fireRange = 10f;
    Vector3 adjustedHeight = new Vector3(0, 10, 0);

    private void Awake()
    {
        bullets = transform.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetToLook();
        //targetToLook.position += adjustedHeight;
        if (targetToLook)
        {
            StareAtEnemy();
            GunModule();
        }
        else
        {
            StopShooting();
        }
    }

    private void SetTargetToLook()
    {
        Enemy[] sceneEnemies = FindObjectsOfType<Enemy>();

        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        closestEnemy = GetClosest(sceneEnemies, closestEnemy);
        targetToLook = closestEnemy;
    }

    private Transform GetClosest(Enemy[] sceneEnemies, Transform enemy)
    {
        Transform _closestEnemy = enemy;

        foreach (Enemy item in sceneEnemies)
        {
            float _testDistance = Vector3.Distance(item.gameObject.transform.position, objectToPan.position);
            float _closestDistance = Vector3.Distance(enemy.position, objectToPan.position);
            if (_testDistance < _closestDistance)
            {
                _closestEnemy = item.gameObject.transform;
            }
        }
        return _closestEnemy;
    }

    private void GunModule()
    {
        if (Vector3.Distance(targetToLook.position, objectToPan.position) < fireRange && targetToLook)
        {
            Shooting();
        } else
        {
            StopShooting();
        }
    }

    private void Shooting()
    {
        bullets.gameObject.SetActive(true) ;
    }

    private void StopShooting()
    {
        bullets.gameObject.SetActive(false);
    }

    private void StareAtEnemy()
    {
        objectToPan.LookAt(targetToLook);
    }
}
