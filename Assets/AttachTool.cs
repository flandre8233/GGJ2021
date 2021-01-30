using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTool : MonoBehaviour
{
    [SerializeField]
    Ship ParentShip;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Throw")
        {
            if (!other.transform.GetComponent<ThrowCollision>().Attachable)
            {
                return;
            }
            int TargetShipBelongCode = other.transform.GetComponent<Parts>().Belong;
            if (TargetShipBelongCode == (ParentShip.IsRed ? 1 : 2))
            {
                other.transform.GetComponent<Parts>().ChangeParentShip(ParentShip);
            }
        }
    }

}
