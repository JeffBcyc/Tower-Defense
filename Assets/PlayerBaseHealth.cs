using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int baseHealth = 100;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI enemyCount;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        healthText.text = baseHealth.ToString();
    }
    private void Update()
    {
        enemyCount.text = enemySpawner.enemyCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("triggered");
        baseHealth -= 10;
        healthText.text = baseHealth.ToString();
    }

}
