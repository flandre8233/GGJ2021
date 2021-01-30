using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//掛在零件上設定綁定的UI
public class UIObject : MonoBehaviour
{
    public UIItem uIItem;

    void Awake()
    {
        Debug.Log($"type{uIItem.uIType}");
    }
}
