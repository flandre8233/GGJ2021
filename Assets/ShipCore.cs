using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCore : MonoBehaviour
{
    [SerializeField]
    Ship ParentShip;

  public int GetBelong(){
      return ParentShip.IsRed ? 1 : 2;
  }
}
