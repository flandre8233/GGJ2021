using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Safe")
        {
            return;
        }

        if (other.tag == "Wall")
        {
            return;
        }
        if (other.tag == "Untagged")
        {
            return;
        }
        if (other.tag == "Attach")
        {
            return;
        }
        if (other.tag == "Safe")
        {
            return;
        }
        if (other.tag == "PowerCore")
        {
            return;
        }

        if (other.tag == "Throw")
        {
            other.transform.GetComponent<Throwing>().ReSetThrowing();
        }

        if (other.tag == "Core")
        {
            int TargetShipBelongCode = other.transform.GetComponent<ShipCore>().GetBelong();
            if (TargetShipBelongCode != GetComponent<Parts>()._Belong)
            {
                OnHitEnemyCore(other.transform.GetComponent<ShipCore>().ParentShip);
            }
        }
        GameObject ExplosionPrefab = Resources.Load<GameObject>("Explosion");
        Instantiate(ExplosionPrefab, gameObject.transform.position, GetRandomAngles());
        if (transform.GetComponent<Throwing>())
        {
            transform.GetComponent<Throwing>().ReSetThrowing();
            GetComponent<Parts>().ResetBelong();

        }

    }

    Quaternion GetRandomAngles()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360f));
    }

    void OnHitEnemyCore(Ship EnemyShip)
    {
        EnemyShip.GetPartControll().OnBeAttack();
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
