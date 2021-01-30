using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Target UI", menuName = "UIItems/Target")]
public class Aim : UIItem
{
    void Awake()
    {
        uIType = UIType.TARGET;
        id = 7;
    }
}
