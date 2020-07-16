using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] Enemy enemyPrefab = null;

    public int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        StartCoroutine(SpawnEnemy());
    }



    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Enemy newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            enemyCount += 1;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }


}
