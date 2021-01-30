using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crew UI", menuName = "UIItems/Crew")]
public class Captain : UIItem
{
    void Awake()
    {
        uIType = UIType.CREW;
        id = 0;
    }
}
