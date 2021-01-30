using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipSpawner : SingletonMonoBehavior<PlayerShipSpawner>
{
    [SerializeField]
    GameObject ShipPrefab;
   
   
   public Ship Spawn(Vector3 Position , bool Isred){
       GameObject SpawnObject = Instantiate(ShipPrefab , Position , Quaternion.Euler(0,0,Random.Range(0,360) ));
       SpawnObject.GetComponent<Ship>().IsRed = Isred;
       return SpawnObject.GetComponent<Ship>();
   }
}
