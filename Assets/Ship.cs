using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool IsRed;
    public inputControll controllBy;
    ShipMovement movement;
    ShipAttack Attack;

    [SerializeField]
    ShipPartControll PartControll;
    [SerializeField]
    CoreSprites CoreSpiteControll;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<ShipMovement>();
        Attack = GetComponent<ShipAttack>();
    }

    public ShipMovement GetMovement()
    {
        return movement;
    }
    public ShipAttack GetAttack()
    {
        return Attack;
    }
    public ShipPartControll GetPartControll()
    {
        return PartControll;
    }public CoreSprites GetCoreSpiteControll()
    {
        return CoreSpiteControll;
    }
}
