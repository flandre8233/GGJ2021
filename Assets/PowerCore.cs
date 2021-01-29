using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : MonoBehaviour
{
    [SerializeField]
    Ship CapturedByShip;

    DelayDoEventHandler CaptureCountdown;

    public void OnCapturedEnter(Ship PlayerShip)
    {
        CapturedByShip = PlayerShip;
        CaptureCountdown = DelayDoEventHandler.Create(OnCaptureTimeEnd, 5f);
    }
    public void OnCapturedExit(Ship PlayerShip)
    {
        if (CapturedByShip == PlayerShip)
        {
            CapturedByShip = null;
            if (CaptureCountdown != null)
            {
                Destroy(CaptureCountdown.gameObject);
            }
        }

    }

    public void OnCaptureTimeEnd()
    {
        print("OnCaptureTimeEnd");
        if (CaptureCountdown != null)
        {
            Destroy(CaptureCountdown.gameObject);
        }
    }
}
