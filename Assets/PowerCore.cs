using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : SingletonMonoBehavior<PowerCore>
{
    [SerializeField]
    List<Ship> CapturedByShip;

    float EntryTime;

    public void OnCapturedEnter(Ship PlayerShip)
    {
        CapturedByShip.Add(PlayerShip);
        EntryTime = Time.time;
    }
    public void OnCapturedExit(Ship PlayerShip)
    {
        CapturedByShip.Remove(PlayerShip);
        EntryTime = int.MaxValue;
    }

    public void OnCaptureTimeEnd()
    {
        print("OnCaptureTimeEnd");
        if (CapturedByShip.Count < 2)
        {
            print("Normal End");
        }
        else
        {
            print("hidden End");
        }
    }

    private void Update()
    {
        if (Time.time - EntryTime >= 5)
        {
            OnCaptureTimeEnd();
            EntryTime = int.MaxValue;
        }
    }
}
