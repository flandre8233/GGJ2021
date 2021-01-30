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
    public List<ui> UIListBlue;
    public List<ui> UIListRed;
    public UIBase uIBase;
    
    void Awake()
    {
        var tmp = new Dictionary<UIType, GameObject>();
        foreach (var i in UIListBlue)
        {
            tmp.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Blue, tmp);
        foreach (var i in UIListRed)
        {
            tmp.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Red, tmp);
    }

    //增加UI至Canvas
    public void AddRandomUI(UIType uIType, PlayerType player)
    {
        List<UIItem> randomBase = new List<UIItem>();
        foreach(var i in uIBase.blue_UIItems)
        {
            if(i.uIType == uIType)
            {
                randomBase.Add(i);
            }
        }
        var result = Random.Range(0, randomBase.Count);
        uiDic[player][uIType].GetComponent<Image>().sprite = randomBase[result].uiSprite;
        uiDic[player][uIType].GetComponent<Image>().color = Color.white;
    }

    //從Canvas隱藏UI
    public void RemoveUI(UIType uIType, PlayerType player)
    {
        uiDic[player][uIType].GetComponent<Image>().color = Color.clear;
    }
}
