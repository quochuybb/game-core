using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    [SerializeField] private float distance;
    [SerializeField] private int hitPoint;
    [SerializeField] private Transform spawnPoint;
    private void Start()
    {
        hitPoint = 3;
    }
    public void OnEnemyInit(Transform spawnPoint)
    {
        hitPoint = 3;
        var transforms = gameObject.transform;
        transforms.position = spawnPoint.position;
        transforms.rotation = spawnPoint.rotation;
        gameObject.SetActive(true);
        this.spawnPoint = spawnPoint;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bullet(Clone)")
        {
            hitPoint--;
        }
        if (hitPoint <= 0)
        {
            gameObject.SetActive(false);
            GameDataManager.AddPoint(1);
            #if  UNITY_EDITOR
            if (Input.GetKey(KeyCode.H))
            {
                GameDataManager.AddPoint(5);
            }
            #endif
            GameSharedUI.Instance.UpdatePointUIText();
        }
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    
    }
}    
