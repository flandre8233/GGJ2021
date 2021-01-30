using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shield UI", menuName = "UIItems/Shield")]
public class Shield : UIItem
{
    void Awake()
    {
        uIType = UIType.SHIELD;
        id = 8;
    }
}
