using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public UIItem[] blue_UIItems;
    public UIItem[] red_UIItems;
    

    public UIItem[] GetUIItems(PlayerType player)
    {
        if(player == PlayerType.Blue)
        {
            return blue_UIItems;
        }
        else
        {
            return red_UIItems;
        }
    }
}
