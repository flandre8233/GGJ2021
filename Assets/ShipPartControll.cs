using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartControll : MonoBehaviour
{
    [SerializeField]
    Ship ship;
    // Start is called before the first frame update
    void Start()
    {
        InitializedParts();
    }

    private void InitializedParts()
    {
        Collider2D[] Colliders = GetComponentsInChildren<Collider2D>();
        foreach (var item in Colliders)
        {
            PartCollider.Create(item, ship);
            //Parts.Create(item.gameObject,ship);
        }
    }

}
