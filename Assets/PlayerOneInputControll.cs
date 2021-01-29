using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneInputControll : inputControll
{
    // Start is called before the first frame update
    void Start()
    {
        keyBind = new PlayerOneKeyBind();
    }
}
