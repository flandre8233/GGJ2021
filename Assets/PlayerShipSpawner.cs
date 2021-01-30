using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipSpawner : SingletonMonoBehavior<PlayerShipSpawner>
{
    [SerializeField]
    GameObject ShipPrefab;
   
   
   public void Spawn(Vector3 Position , bool Isred){
       GameObject SpawnObject = Instantiate(ShipPrefab , Position , Quaternion.identity);
       SpawnObject.GetComponent<Ship>().IsRed = Isred;
   }
}
