using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    [SerializeField] private Canvas Shop;
    public void CloseShop()
    {
        Shop.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void BuyShop()
    {
        
    }
}
