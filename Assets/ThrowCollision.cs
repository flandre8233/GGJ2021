using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            return;
        }
        GameObject ExplosionPrefab = Resources.Load<GameObject>("Explosion");
        Instantiate(ExplosionPrefab, gameObject.transform.position, GetRandomAngles());

        if (other.tag == "Throw")
        {
            other.transform.GetComponent<Throw>().ReSetThrowing();
        }

        if (other.tag == "Core")
        {
            int TargetShipBelongCode = other.transform.GetComponent<ShipCore>().GetBelong();
            if (TargetShipBelongCode == 1)
            {
                OnHitRedCore();
            }
            else
            {
                OnHitBlueCore();
            }
        }
        transform.GetComponent<Throw>().ReSetThrowing();
    }

    Quaternion GetRandomAngles()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360f));
    }


    void OnHitRedCore()
    {
        print("OnHitRedCore");
    }
    void OnHitBlueCore()
    {
        print("OnHitBlueCore");

    }
}
