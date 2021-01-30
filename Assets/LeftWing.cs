using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWing : Parts
{
    float OrlSpeed = 0;

    public override void Throw()
    {
        base.Throw();
    }

    public override void Attach()
    {
        base.Attach();
        Parentship.GetMovement().LeftTurningSpeed = OrlSpeed;
    }

    public override void Detach()
    {
        base.Detach(); 
        OrlSpeed = Parentship.GetMovement().LeftTurningSpeed;
        Parentship.GetMovement().LeftTurningSpeed = OrlSpeed * 0.75f;
    }
}
