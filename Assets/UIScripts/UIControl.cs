using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//掛在Canvas上，控管所有UI的生成和隱藏
public class UIControl : MonoBehaviour
{
    [System.Serializable]public struct ui
    {
        public UIType types;
        public GameObject uiImage;
    }
    public Dictionary<PlayerType,Dictionary<UIType, GameObject>> uiDic = new Dictionary<PlayerType, Dictionary<UIType, GameObject>>(); 
    public List<ui> UIListA;
    public List<ui> UIListB;
    
    void Awake()
    {
        
    }
    void Start()
    {
        var tmp = new Dictionary<UIType, GameObject>();
        foreach (var i in UIListA)
        {
            tmp.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Player1, tmp);
        foreach (var i in UIListB)
        {
            tmp.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Player2, tmp);
    }

    //增加UI至Canvas
    public void AddUI(UIItem uIItem, PlayerType player)
    {
        uiDic[player][uIItem.uIType].GetComponent<Image>().sprite = uIItem.uiSprite;
        uiDic[player][uIItem.uIType].GetComponent<Image>().color = Color.white;
    }

    //從Canvas隱藏UI
    public void RemoveUI(UIItem uIItem, PlayerType player)
    {
        uiDic[player][uIItem.uIType].GetComponent<Image>().color = Color.clear;
    }
}
