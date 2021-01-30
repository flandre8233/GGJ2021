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
        UpdatePaint();
    }

    void UpdatePaint()
    {
        GetComponent<SpriteRenderer>().sprite = PartsViewPainter.instance.GetNewPaint(ID, Belong);
    }

    public virtual void Throw()
    {
        Throwing.Create(gameObject);
        Detach();
    }public virtual void ThrowRandom()
    {
        ThrowingRandom.Create(gameObject);
        Detach();
    }

    public virtual void Attach()
    {
        Destroy(GetComponent<Throwing>());
        Parentship.GetPartControll().AddParts(this);
        UpdatePaint();
    }

    public virtual void Detach()
    {
        Parentship.GetPartControll().RemoveParts(ID);
    }

    public int GetID()
    {
        return ID;
    }

    public void ChangeParentShip(Ship _ParentShip)
    {
        Parentship = _ParentShip;
        Belong = _ParentShip.IsRed ? 1 : 2;
        Attach();
    }

    public void ResetBelong()
    {
        Belong = 0;
        UpdatePaint();
        gameObject.tag = "Safe";
    }
}

public interface IThrow
{
    void Throw();
    void ThrowRandom();
}

public interface IParts
{
    void Attach();
    void Detach();
}

