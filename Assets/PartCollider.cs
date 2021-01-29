using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollider : MonoBehaviour
{
    [SerializeField]
    Ship ship;
    public static PartCollider Create(Collider2D collider, Ship ParentShip)
    {
        PartCollider Ret = collider.gameObject.AddComponent<PartCollider>();
        Ret.ship = ParentShip;
        Ret.tag = "Player";
        return Ret;
    }

    public Ship GetShip(){
        return ship;
    }

}
