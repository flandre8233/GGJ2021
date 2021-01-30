using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cannon UI", menuName = "UIItems/Main_Cannon")]
public class Gun : UIItem
{
    void Awake()
    {
        uIType = UIType.MAIN_CANNON;
        id = 1;
    }
}
