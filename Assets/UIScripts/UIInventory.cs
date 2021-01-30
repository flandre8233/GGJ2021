using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory
{
    public List<UIItem> Container = new List<UIItem>();

    //I遊戲一開始產生所有在List的UI
    public void InitInventory(List<UIItem> uiItem)
    {
        foreach (var i in uiItem)
        {
            Container.Add(i);
        }
    }

    //增加UI至Container(回傳是否增加成功)
    public bool AddUI(UIItem uIItem)
    {
        bool hasUI = false;
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].uIType == uIItem.uIType)
            {
                hasUI = true;
            }
        }
        if(!hasUI)
        {
            Container.Add(uIItem);
        }
        return hasUI;
    }

    //從Container刪減UI(回傳刪減的UI為何種UIItem型別)
    public UIItem RemoveUI()
    {
        if(Container.Count == 0)
            return null;
        var tmp = Container[Random.Range(0, Container.Count)];
        Container.Remove(tmp);
        return tmp;
    }
}
