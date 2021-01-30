using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet UI", menuName = "UIItems/Bullet")]
public class Bullet : UIItem
{
    public void Awake()
    {
        uIType = UIType.BULLET;
    }
}
