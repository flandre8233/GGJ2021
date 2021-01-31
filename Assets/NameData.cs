using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameData : MonoBehaviour
{
   
   [SerializeField]
   string[] NameArray;
public string ConText;
   public string GetRandomName(){
       return NameArray[Random.Range(0,NameArray.Length)];
   }
}
