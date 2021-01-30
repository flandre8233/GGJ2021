using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour, IThrow, IParts
{
    protected Ship Parentship;
    public static Parts Create(GameObject TargetObject, Ship ship)
    {
        Parts Ret = TargetObject.AddComponent<Parts>();
        Ret.Parentship = ship;
        return Ret;
    }

    public virtual void Throw()
    {
        gameObject.AddComponent<Throw>();
        Detach();
    }

    public virtual void Attach()
    {
    }

    public virtual void Detach()
    {
    }

}

public interface IThrow
{
    void Throw();
}

public interface IParts
{
    void Attach();
    void Detach();
}

