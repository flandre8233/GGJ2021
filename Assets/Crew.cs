using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : Parts
{
    public override void Throw()
    {
        base.Throw();
        gameObject.AddComponent<AmongUsEasterEgg>();
    }

    public override void Attach()
    {
        base.Attach();
        Parentship.GetCoreSpiteControll().SetCoreSpritesBroken(false);
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
        base.Detach();
        Parentship.GetCoreSpiteControll().SetCoreSpritesBroken(true);
        Invoke("LostControll", 0.1f);
        Invoke("RecoverControll", 0.1f + 2);
    }
}
