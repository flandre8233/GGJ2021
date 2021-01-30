using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingRandom : Throwing
{
   public static new ThrowingRandom Create(GameObject TargetObject)
    {
        ThrowingRandom Ret = TargetObject.AddComponent<ThrowingRandom>();
        return Ret;
    }
    protected override void Start()
      {
        base.Start();
        SetRandomOrlDir();
    }
}
