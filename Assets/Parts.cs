using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour, IThrow
{
    Ship Parentship;
    public static Parts Create(GameObject TargetObject , Ship ship)
    {
        Parts Ret = TargetObject.AddComponent<Parts>();
        Ret.Parentship = ship;
        return Ret;
    }

    public virtual void Throw()
    {
        gameObject.AddComponent<Throw>();
    }

}

public interface IThrow
{
    void Throw();
}

