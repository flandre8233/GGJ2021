using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [SerializeField]
public bool Egg;

    [SerializeField]
    Ship ship;
    public static Parts Create(GameObject TargetObject, Ship ParentShip)
    {
        Parts Ret = TargetObject.AddComponent<Parts>();
        Ret.ship = ParentShip;
        return Ret;
    }

    public Ship GetShip()
    {
        return ship;
    }


}
