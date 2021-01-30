using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsSpawner : SingletonMonoBehavior<PartsSpawner>
{
    [SerializeField]
    GameObject[] PartsPrefab;

    public static Parts SpawnPart(int Index, Ship ParentShip, Transform PointParent)
    {
        GameObject SpawnObject = Instantiate(instance.PartsPrefab[Index], PointParent);
        Parts Ret = SpawnObject.GetComponent<Parts>();
        Ret.Init(Index,ParentShip);
        return Ret;
    }
}
