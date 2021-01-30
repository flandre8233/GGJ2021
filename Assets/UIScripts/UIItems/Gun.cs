using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun UI", menuName = "UIItems/Gun")]
public class Gun : UIItem
{
    void Awake()
    {
        uIType = UIType.GUN;
    }
}
