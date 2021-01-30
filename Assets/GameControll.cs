using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : SingletonMonoBehavior<GameControll>
{
    [SerializeField]
    PlayerOneInputControll RedControll;
    [SerializeField]
    PlayerTwoInputControll BlueControll;

    [SerializeField]
    Cinemachine.CinemachineTargetGroup CameraTargetGroup;
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
        RedControll.Ship = PlayerShipSpawner.instance.Spawn(RandomWorldPos, true);
        RedControll.Ship.controllBy = RedControll;
        CameraTargetGroup.AddMember(RedControll.Ship.transform,1,1);
    }

    void RecoverBlueShip()
    {
        Vector3 RandomWorldPos = GetRandomSpawnPosition();
       BlueControll.Ship =  PlayerShipSpawner.instance.Spawn(RandomWorldPos, false);
        BlueControll.Ship.controllBy = BlueControll;
        CameraTargetGroup.AddMember(BlueControll.Ship.transform,1,1);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float X = Random.Range(-20,20);
        float Y = Random.Range(-12,12);
        return new Vector3(X,Y,0);
    }

}
