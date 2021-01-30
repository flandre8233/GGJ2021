using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Captain UI", menuName = "UIItems/Captain")]
public class Captain : UIItem
{
    void Awake()
    {
        uIType = UIType.CAPTAIN;
    }
}
