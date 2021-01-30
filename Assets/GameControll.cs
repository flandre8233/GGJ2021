using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : SingletonMonoBehavior<GameControll>
{
//[SerializeField]
    public void OnSomeShipDead(bool IsRed)
    {
        if (IsRed)
        {
            Invoke("RecoverRedShip", 5);
        }
        else
        {
            Invoke("RecoverBlueShip", 5);
        }
    }

    void RecoverRedShip()
    {
        Vector3 RandomWorldPos = GetRandomSpawnPosition();
        PlayerShipSpawner.instance.Spawn(RandomWorldPos, true);
       // inputControll
    }

    void RecoverBlueShip()
    {
        Vector3 RandomWorldPos = GetRandomSpawnPosition();
        PlayerShipSpawner.instance.Spawn(RandomWorldPos, false);

    }

    Vector3 GetRandomSpawnPosition()
    {
return new Vector3();
    }

}
