using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTool : MonoBehaviour
{
    [SerializeField]
    Ship ParentShip;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Safe")
        {
            if (!other.transform.GetComponent<ThrowCollision>().Attachable)
            {
                return;
            }
            int TargetShipBelongCode = other.transform.GetComponent<Parts>().Belong;
            if (TargetShipBelongCode == (ParentShip.IsRed ? 1 : 2) || TargetShipBelongCode == 0)
            {
                if (ParentShip.GetPartControll().IsNeedThisParts(other.transform.GetComponent<Parts>().GetID()))
                {
                    other.transform.GetComponent<Parts>().ChangeParentShip(ParentShip);
                }
            }
        }
    }

}
