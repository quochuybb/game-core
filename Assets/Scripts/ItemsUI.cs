using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemsUI : MonoBehaviour
{
    [SerializeField] Image ItemsImage;
    [SerializeField] TMP_Text ItemsName;
    [SerializeField] TMP_Text itemsPrice;
    [SerializeField] Button itemsPurchase;

    public void SetitemsPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }
}
