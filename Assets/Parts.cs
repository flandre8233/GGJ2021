using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour, IThrow
{
    [SerializeField]
    Ship ship;
    public static Parts Create(GameObject TargetObject, Ship ParentShip)
    {
        Parts Ret = TargetObject.AddComponent<Parts>();
        Ret.ship = ParentShip;
        return Ret;
    }

    public virtual void Throw()
    {
        gameObject.AddComponent<Throw>();
    }

    public Ship GetShip()
    {
        return ship;
    }
}

public interface IThrow
{
    void Throw();
}

