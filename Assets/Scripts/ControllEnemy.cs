using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> ListEnemy;
    [SerializeField] private GameObject EnemyPrehabs;
    [SerializeField] private Transform spawnPoint;
    private void OnEnable()
    {
        ListEnemy = new List<GameObject>();
    }

    public void Spawn()
    {
        var enemyEnable = ListEnemy.FindAll(o => o.activeInHierarchy == false);
        AIChase enemyController = null;
        if (enemyEnable.Count > 0)
        {
            enemyController = enemyEnable[0].GetComponent<AIChase>();
            enemyController.OnEnemyInit(spawnPoint);
        }
        else
        {
            var enemy = Instantiate(EnemyPrehabs);
            enemyController = enemy.GetComponent<AIChase>();
            ListEnemy.Add(enemy);
        }
        enemyController.OnEnemyInit(spawnPoint);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
