using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private List<GameObject> bulletList;   
    [SerializeField] private Transform shootPos;
    [SerializeField] private GameObject bulletPrefab;

    private void OnEnable()
    {
        bulletList = new List<GameObject>();
    }
    
    public void Shoot()
    {
        var bulletEnable = bulletList.FindAll(o => o.activeInHierarchy == false);
        Bullet bulletController = null;
        if (bulletEnable.Count > 0)
        {
            bulletController = bulletEnable[0].GetComponent<Bullet>();
            bulletController.OnBulletInit(shootPos);
            bulletController.Fly();
        }
        else
        {
            var bullet = Instantiate(bulletPrefab);
            bulletController = bullet.GetComponent<Bullet>();
            bulletList.Add(bullet);
        }
        bulletController.OnBulletInit(shootPos);
        bulletController.Fly();
    }
}
