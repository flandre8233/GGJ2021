using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoInputControll : inputControll
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        keyBind = new PlayerTwoKeyBind();
    }
}
