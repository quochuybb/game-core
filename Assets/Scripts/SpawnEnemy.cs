using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private bool canSpwan = true;
    [SerializeField] private float spawnRate = 5.0f;
    [SerializeField] public ControllEnemy EnemySpawn;

    private void Start()
    {
        StartCoroutine(Dospawn());
    }

    private IEnumerator Dospawn()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpwan)
        {
            yield return wait;
            EnemySpawn.Spawn();
        }    
    }
}
