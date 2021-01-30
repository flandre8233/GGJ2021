using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Parts
{
    public override void Throw()
    {
        base.Throw();
        gameObject.AddComponent<AmongUsEasterEgg>();
    }
}
