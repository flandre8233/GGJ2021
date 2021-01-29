using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ShipThrowPartControll : MonoBehaviour
{
private void Start() {
}

    public void ThrowRandomPart()
    {
        List<Collider2D> Colliders = GetComponentsInChildren<Collider2D>().ToList();
        int ThrowIndex = Random.Range(0, Colliders.Count);
        GameObject ThrowTarget = Colliders[ThrowIndex].gameObject;
        Colliders.RemoveAt(ThrowIndex);
        ThrowTarget.AddComponent<Throw>();
    }

    public bool IsStillHaveAmmo(){
        List<Collider2D> Colliders = GetComponentsInChildren<Collider2D>().ToList();
        return Colliders.Count > 0;
    }
}
