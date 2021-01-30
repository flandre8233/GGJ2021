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

    public override void Attach()
    {

    }

    void LostControll()
    {
        Parentship.controllBy.RemoveUpdate();
    }
    void RecoverControll()
    {
        Parentship.controllBy.AddUpdate();
    }


    public override void Detach()
    {
        Invoke("LostControll", 0.1f);
        Invoke("RecoverControll", 0.1f + 1);
    }
}
