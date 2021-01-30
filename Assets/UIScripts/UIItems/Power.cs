using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power UI", menuName = "UIItems/Power")]
public class Power : UIItem
{
    void Awake()
    {
        uIType = UIType.POWER;
    }
}
