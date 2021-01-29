using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    ShipMovement movement;
    ShipAttack Attack;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<ShipMovement>();
        Attack = GetComponent<ShipAttack>();
    }

    public ShipMovement GetMovement()
    {
        return movement;
    } public ShipAttack GetAttack()
    {
        return Attack;
    }
}
