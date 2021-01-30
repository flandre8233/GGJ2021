using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Aim UI", menuName = "UIItems/Aim")]
public class Aim : UIItem
{
    void Awake()
    {
        uIType = UIType.AIM_SYSTEM;
    }
}
