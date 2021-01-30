using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon UI", menuName = "UIItems/Weapon")]
public class Bullet : UIItem
{
    public void Awake()
    {
        uIType = UIType.WEAPON;
        id = 6;
    }
}
