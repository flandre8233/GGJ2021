using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Member Window UI", menuName = "UIItems/Member_window")]
public class Member_window : UIItem
{
    public void Awake()
    {
        uIType = UIType.MEMBER_WINDOW;
    }
}
