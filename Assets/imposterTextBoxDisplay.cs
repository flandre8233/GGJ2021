using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imposterTextBoxDisplay : TalkTextBoxDisplayControll
{
     
    protected override void Start()
    {
        base.Start();
        string Name = GetComponent<NameData>().GetRandomName();
        StartTalking(Name +  GetComponent<NameData>().ConText);
    }
}
