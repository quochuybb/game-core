using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemsShopDataBase", menuName = "Shoping/Items shop database")]
public class ItemsDataBase : ScriptableObject
{
    public ItemsShop[] items;

    public int ItemsCount
    {
        get { return items.Length; }
    }

    public ItemsShop GetItem(int index)
    {
        return items[index];
    }

    public void PurchesItems(int index)
    {
        items[index].isPurchased = true;
    }
}
