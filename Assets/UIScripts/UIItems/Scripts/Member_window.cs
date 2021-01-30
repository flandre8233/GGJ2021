using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crew Screen UI", menuName = "UIItems/Crew_Screen")]
public class Member_window : UIItem
{
    public void Awake()
    {
        uIType = UIType.CREW_SCREEN;
        id = 2;
    }
}
