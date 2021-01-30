using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mission UI", menuName = "UIItems/Mission")]
public class Mission : UIItem
{
    public void Awake()
    {
        uIType = UIType.MISSION;
        id = 5;
    }
}
