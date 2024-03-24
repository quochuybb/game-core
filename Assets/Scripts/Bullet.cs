using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public Transform shootPos;
    public float damage = 30;
    private Vector3 shootLocation;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        collision.gameObject.GetComponent<TakeDmg>()?.TakeDamage();
        gameObject.SetActive(false);
    }

    public void OnBulletInit(Transform shootPos)
    {
        var transforms = gameObject.transform;
        transforms.position = shootPos.position;
        transforms.rotation = shootPos.rotation;
        gameObject.SetActive(true);
        this.shootPos = shootPos;
    }

    public void Fly()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        SetPosWhenShoot();
        rb.AddForce(shootPos.up * 10, ForceMode2D.Impulse);
    }

    public void Update()
    {
        if (CaculateDistance() > 20f) gameObject.SetActive(false);
    }

    public void SetPosWhenShoot()
    {
        this.shootLocation = transform.position;
    }

    public float CaculateDistance()
    {
        return Vector3.Distance(this.shootLocation, gameObject.transform.position);
    }
}