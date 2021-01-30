using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollision : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
       GameObject ExplosionPrefab = Resources.Load<GameObject>("Explosion");
       Instantiate(ExplosionPrefab , gameObject.transform.position,Quaternion.Euler(0,0,Random.Range(0,360f)));
   }
}
