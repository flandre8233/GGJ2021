using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBooster : Parts
{
    float OrlSpeed = 0;
    public override void Throw()
    {
        base.Throw();
    }

    public override void Attach()
    {
        base.Attach();
        Parentship.GetMovement().Speed = OrlSpeed;
    }

    public override void Detach()
    {
        base.Detach();
        OrlSpeed = Parentship.GetMovement().Speed;
        Parentship.GetMovement().Speed = OrlSpeed / 2;
    }
}
