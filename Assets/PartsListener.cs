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
        print("OnRedShipAddParts");
    }

    void OnBlueShipAddParts(int PartsID)
    {
        print("OnBlueShipAddParts");

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
        print("OnRedShipRemoveParts");

    }

    void OnBlueShipRemoveParts(int PartsID)
    {
        print("OnBlueShipRemoveParts");

    }
}
