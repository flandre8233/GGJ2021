using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUIControl : MonoBehaviour
{
    public UIInventory uiInvertory = new UIInventory();
    public UIControl uIControl;
    public PlayerType playerType;
    void Start()
    {
        uIControl = FindObjectOfType<UIControl>();
        uiInvertory.InitInventory(this);
    }

    // Update is called once per frame
    void Update()
    {
        //按下空白鍵隨機刪除UI
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var result = uiInvertory.RemoveFromInventory();
            if(result != null)
            {
                //uIControl.RemoveUI(result, playerType, this.transform);
            }
        }
    }

    //碰到零件增加UI
    void OnTriggerStay2D(Collider2D col)
    {   
        
        bool result = false;
        if(col.GetComponent<UIObject>())
        {
            
            result = uiInvertory.AddToInventory(col.GetComponent<UIObject>().uIItem);
            //Debug.Log(result); 
        }
        if(result)
        {
            //uIControl.AddUI(col.GetComponent<UIObject>().uIItem, playerType);
        }
    }
}

