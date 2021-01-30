using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//掛在Canvas上，控管所有UI的生成和隱藏
public class UIControl : SingletonMonoBehavior<UIControl>
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
        var tmp1 = new Dictionary<UIType, GameObject>();
        var tmp2 = new Dictionary<UIType, GameObject>();
        foreach (var i in UIListBlue)
        {
            tmp1.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Blue, tmp1);
        
        foreach (var i in UIListRed)
        {
            tmp2.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Red, tmp2);
    }

    //增加UI至Canvas
    public void AddRandomUI(UIType uIType, PlayerType player)
    {
        List<UIItem> randomBase = new List<UIItem>();
        foreach(var i in uIBase.GetUIItems(player))
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
        Debug.Log(uiDic[player][uIType].name);
        uiDic[player][uIType].GetComponent<Image>().color = Color.clear;
    }
}
