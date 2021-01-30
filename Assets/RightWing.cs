using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWing : Parts
{
    float OrlSpeed = 0;
     public override void Throw()
    {
        base.Throw();
    }

     public override void Attach()
    {
        base.Attach();
       Parentship.GetMovement().RightTurningSpeed = OrlSpeed;
       transform.eulerAngles = new Vector3(0,0,70);
    }

    public override void Detach()
    {
        base.Detach();
       OrlSpeed = Parentship.GetMovement().RightTurningSpeed;
       Parentship.GetMovement().RightTurningSpeed = OrlSpeed/4;
    }
}
