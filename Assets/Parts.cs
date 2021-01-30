using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour, IThrow, IParts
{
    [SerializeField]
    int ID;
    protected Ship Parentship;

    public void Init(int _ID, Ship _Parentship)
    {
        ID = _ID;
        Parentship = _Parentship;
    }


    public virtual void Throw()
    {
        gameObject.AddComponent<Throw>();
        Detach();
    }

    public virtual void Attach()
    {
        Parentship.GetPartControll().AddParts(this);
    }

    public virtual void Detach()
    {
        Parentship.GetPartControll().RemoveParts(ID);
    }

    public int GetID()
    {
        return ID;
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

