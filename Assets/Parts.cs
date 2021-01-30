using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour, IThrow, IParts
{
    // 0 : white
    // 1 : Red 
    // 2 : blue 
    [SerializeField]
    int ID;

    public int Belong;
    protected Ship Parentship;

    public void Init(int _ID, Ship _Parentship)
    {
        ID = _ID;
        Parentship = _Parentship;
        Belong = Parentship.IsRed ? 1 : 2;
    }


    public virtual void Throw()
    {
        Throwing.Create(gameObject);
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

