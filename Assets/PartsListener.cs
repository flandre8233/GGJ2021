using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsListener : SingletonMonoBehavior<PartsListener>
{
    // 0 : Crew
    // 1 : Cannon
    // 2 : Dorm
    // 3 : LeftEngine
    // 4 : LeftWing
    // 5 : Mainbooster
    // 6 : RightAmmuntion
    // 7 : RightWing
    // 8 : RightWingBooster
    public void OnSomeShipAddParts(Ship ship, int PartsID)
    {
        if (ship.IsRed)
        {
            OnRedShipAddParts(PartsID);
        }
        else
        {
            OnBlueShipAddParts(PartsID);
        }

    }

    void OnRedShipAddParts(int PartsID)
    {
        if (!UIControl.instance)
        {
            return;
        }
        print("OnRedShipAddParts");
        UIControl.instance.AddRandomUI((UIType)PartsID, PlayerType.Red);
    }

    void OnBlueShipAddParts(int PartsID)
    {
        if (!UIControl.instance)
        {
            return;
        }
        print("OnBlueShipAddParts");
        UIControl.instance.AddRandomUI((UIType)PartsID, PlayerType.Blue);
    }

    public void OnSomeShipRemoveParts(Ship ship, int PartsID)
    {
        if (ship.IsRed)
        {
            OnRedShipRemoveParts(PartsID);
        }
        else
        {
            OnBlueShipRemoveParts(PartsID);
        }

    }

    void OnRedShipRemoveParts(int PartsID)
    {
        if (!UIControl.instance)
        {
            return;
        }
        print("OnRedShipRemoveParts");
        UIControl.instance.RemoveUI((UIType)PartsID, PlayerType.Red);
    }

    void OnBlueShipRemoveParts(int PartsID)
    {
        if (!UIControl.instance)
        {
            return;
        }
        print("OnBlueShipRemoveParts");
        UIControl.instance.RemoveUI((UIType)PartsID, PlayerType.Blue);
    }
}
