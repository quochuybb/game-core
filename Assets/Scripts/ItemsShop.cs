using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemsShop
{
    public Sprite image;
    public string name;
    public string types;
    [Range(0, 100)] public float atk;
    [Range(0, 100)] public float hp;
    [Range(0, 100)] public int bullet;
    public int price;
    public bool isPurchased;
}
