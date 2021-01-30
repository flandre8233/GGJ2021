using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIItem: ScriptableObject
{
    public int id;
    public string uiName;
    public UIType uIType;
    public UIStyle uIStyle;
    public Sprite uiSprite;
    
    [TextArea(5, 10)]
    public string description;
}

public enum UIType 
{
    BULLET,
    SYSTEM,
    MEMBER_WINDOW,
    CAPTAIN,
    MISSION,
    GUN,
    AIM_SYSTEM,
    POWER,
    SHIELD
}

public enum UIStyle
{
    GAME_1,
    GAME_2,
    GAME_3
}
