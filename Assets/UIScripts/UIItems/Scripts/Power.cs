using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Energy UI", menuName = "UIItems/Energy")]
public class Power : UIItem
{
    void Awake()
    {
        uIType = UIType.ENERGY;
        id = 3;
    }
}
