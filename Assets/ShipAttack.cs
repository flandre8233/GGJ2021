using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttack : MonoBehaviour
{
    [SerializeField]
    ShipThrowPartControll controll;
    public void Throw()
    {
        if (controll.IsStillHaveAmmo())
        {
            controll.ThrowRandomPart();
        }
    }
}
