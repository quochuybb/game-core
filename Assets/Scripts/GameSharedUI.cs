using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSharedUI : MonoBehaviour
{
    #region Singleton class: GameSharedUI

    public static GameSharedUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] private TMP_Text[] pointUIText;

    private void Start()
    {
        UpdatePointUIText();
    }

    public void UpdatePointUIText()
    {
        for (int i = 0; i < pointUIText.Length; i++)
        {
            SetPointText(pointUIText[i], GameDataManager.GetPoint());
        }
    }

    void SetPointText(TMP_Text textmesh, int value)
    {
        if (value >= 1000)
        {
            textmesh.text = string.Format("{0}K.{1}", (value / 1000), GetFirstDigitFromNumber(value % 1000));
        }
        else
        {
            textmesh.text = value.ToString();
        }
    }

    int GetFirstDigitFromNumber(int num)
    {
        return int.Parse(num.ToString()[0].ToString());
    }
}
