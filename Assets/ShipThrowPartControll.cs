using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ShipThrowPartControll : MonoBehaviour
{
    private void Start()
    {
    }

    public void ThrowRandomPart()
    {
        List<Parts> PartsList = GetComponentsInChildren<Parts>().ToList();
        int ThrowIndex = Random.Range(0, PartsList.Count);
        Parts ThrowTarget = PartsList[ThrowIndex];
        PartsList.RemoveAt(ThrowIndex);

        IThrow throwCMD = ThrowTarget;
        throwCMD.Throw();
    }

    public void ThrowRandomPartRandom()
    {
        List<Parts> PartsList = GetComponentsInChildren<Parts>().ToList();
        int ThrowIndex = Random.Range(0, PartsList.Count);
        Parts ThrowTarget = PartsList[ThrowIndex];
        PartsList.RemoveAt(ThrowIndex);

        IThrow throwCMD = ThrowTarget;
        throwCMD.ThrowRandom();
    }

    public bool IsStillHaveAmmo()
    {
        List<Collider2D> Colliders = GetComponentsInChildren<Collider2D>().ToList();
        return Colliders.Count > 0;
    }
}
