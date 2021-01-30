using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ShipPartControll : MonoBehaviour
{
    [SerializeField]
    Ship ship;
    [SerializeField]
    Transform[] PartsPoints;
    [SerializeField]
    Parts[] Inventory;

    // Start is called before the first frame update
    void Start()
    {
        InitializedColliders();
        InitializedParts();
    }

    private void InitializedColliders()
    {
        Collider2D[] Colliders = GetComponentsInChildren<Collider2D>();
        foreach (var item in Colliders)
        {
            PartCollider.Create(item, ship);
        }
    }

    private void InitializedParts()
    {
        Inventory = new Parts[PartsPoints.Length];
        for (int i = 0; i < PartsPoints.Length; i++)
        {
            Transform PartsPoint = PartsPoints[i];
            Parts SinglePart = PartsSpawner.SpawnPart(i, ship, PartsPoint);
            AddParts(SinglePart);
        }
    }

    public void AddParts(Parts _Parts)
    {
        Inventory[_Parts.GetID()] = _Parts;
        _Parts.transform.parent = PartsPoints[_Parts.GetID()];
        PartsListener.instance.OnSomeShipAddParts(ship, _Parts.GetID());
    }

    public void RemoveParts(int Index)
    {
        Inventory[Index] = null;

        PartsListener.instance.OnSomeShipRemoveParts(ship, Index);
    }

    public Parts GetRandomParts()
    {
        List<int> StillHaveIndexes = new List<int>();
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] != null)
            {
                StillHaveIndexes.Add(i);
            }
        }
        int RandomIndex = StillHaveIndexes[Random.Range(0, StillHaveIndexes.Count)];
        return Inventory[RandomIndex];
    }

    public bool IsNeedThisParts(int ID)
    {
        return Inventory[ID] == null;
    }

    public int GetHP()
    {
        List<int> StillHaveIndexes = new List<int>();
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] != null)
            {
                StillHaveIndexes.Add(i);
            }
        }
        return StillHaveIndexes.Count;
    }

    public void OnBeAttack()
    {
        if (GetHP() > 1)
        {
            GetComponent<ShipThrowPartControll>().ThrowRandomPartRandom();
            GetComponent<ShipThrowPartControll>().ThrowRandomPartRandom();
        }else{
            Debug.Log("Set Dead");
            Destroy( ship.gameObject);
            GameControll.instance.OnSomeShipDead(ship.IsRed);
        }

    }
}
