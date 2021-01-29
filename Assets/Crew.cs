using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : Parts
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Throw()
    {
        base.Throw();
        gameObject.AddComponent<AmongUsEasterEgg>();
    }
}
