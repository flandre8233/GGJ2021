using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class inputControll : MonoBehaviour
{
    [SerializeField]
    public Ship Ship;
    protected IkeyBind keyBind;
    protected virtual void Start()
    {
        Ship.controllBy = this;
        AddUpdate();
    }
    void ToUpdate()
    {
        if (!Ship)
        {
            return;
        }

        if (keyBind.IsHoldMoveForward())
        {
            Ship.GetMovement().MoveForward();
        }
        if (keyBind.IsHoldMoveLeft())
        {
            Ship.GetMovement().TurnLeft();
        }
        if (keyBind.IsHoldMoveRight())
        {
            Ship.GetMovement().TurnRight();
        }
        if (keyBind.IsHoldBreak())
        {
            Ship.GetMovement().MoveDown();
        }
        if (keyBind.IsOpenFire())
        {
            Ship.GetAttack().Throw();
        }
    }

    public void AddUpdate()
    {
        globalUpdateManager.registerUpdateDg(ToUpdate);
    }

    public void RemoveUpdate()
    {
        globalUpdateManager.UnregisterUpdateDg(ToUpdate);
    }

}

public interface IkeyBind
{
    bool IsHoldMoveForward();
    bool IsHoldMoveLeft();
    bool IsHoldMoveRight();
    bool IsHoldBreak();

    bool IsOpenFire();


}

public class PlayerOneKeyBind : IkeyBind
{
    public bool IsHoldMoveForward()
    {
        return Input.GetKey(KeyCode.W);
    }
    public bool IsHoldMoveLeft()
    {
        return Input.GetKey(KeyCode.A);
    }
    public bool IsHoldMoveRight()
    {
        return Input.GetKey(KeyCode.D);
    }
    public bool IsHoldBreak()
    {
        return Input.GetKey(KeyCode.S);
    }
    public bool IsOpenFire()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
public class PlayerTwoKeyBind : IkeyBind
{
    public bool IsHoldMoveForward()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }
    public bool IsHoldMoveLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }
    public bool IsHoldMoveRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
    public bool IsHoldBreak()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }
    public bool IsOpenFire()
    {
        return Input.GetKeyDown(KeyCode.Alpha0);
    }
}