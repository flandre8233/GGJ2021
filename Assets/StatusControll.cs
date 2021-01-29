using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusControll : SingletonMonoBehavior<StatusControll>
{
    Status NowStatus;

    public static void ToNewStatus(Status NewStatus)
    {
        instance.NowStatus = NewStatus;
        instance.NowStatus.Start();
    }

    private void Update()
    {
        if (NowStatus != null)
        {
            NowStatus.Update();
        }
    }
}
