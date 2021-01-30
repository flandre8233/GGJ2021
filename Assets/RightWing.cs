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
       Invoke("Delay" , 0.1f);
    }

    void Delay(){
        transform.localEulerAngles = new Vector3(0,0,70);
    }

    public override void Detach()
    {
        base.Detach();
       OrlSpeed = Parentship.GetMovement().RightTurningSpeed;
       Parentship.GetMovement().RightTurningSpeed = OrlSpeed* 0.75f;
    }
}
