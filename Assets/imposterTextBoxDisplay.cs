using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imposterTextBoxDisplay : TalkTextBoxDisplayControll
{
     
    protected override void Start()
    {
        base.Start();
        string Name = GetComponent<NameData>().GetRandomName();
        string ConText = " was not an imposter.";
        StartTalking(Name + ConText);
    }
}
