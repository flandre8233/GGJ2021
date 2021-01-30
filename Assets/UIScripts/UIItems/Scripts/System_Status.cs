using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New System UI", menuName = "UIItems/System_Status")]
public class System_Status : UIItem
{
    public void Awake()
    {
        uIType = UIType.SYSTEM;
        id = 4;
    }
}
