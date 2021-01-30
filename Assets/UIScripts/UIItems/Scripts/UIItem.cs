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
    public PlayerType playerType;

    [TextArea(5, 10)]
    public string description;
}

public enum UIType 
{
    CREW,   // 0 : Crew
    MAIN_CANNON,    // 1 : Cannon
    CREW_SCREEN,    // 2 : Dorm
    ENERGY,     // 3 : LeftEngine
    SYSTEM,     // 4 : LeftWing
    MISSION,    // 5 : Mainbooster
    WEAPON,     // 6 : RightAmmuntion
    TARGET,     // 7 : RightWing
    SHIELD  // 8 : RightWingBooster
}

public enum UIStyle
{
    Default,
    AMONG_US,
    GAME_3
}


public enum PlayerType
{
    Blue,
    Red
}