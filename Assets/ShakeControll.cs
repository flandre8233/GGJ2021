using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeControll : MonoBehaviour
{
    Quaternion OrlRotation;

    Vector3 TargetV3;
    bool IsOpening;

    [SerializeField] float ReNewTargetTime;
    [SerializeField] float ReNewTargetDisantce;
    [SerializeField] float ShakeMovementSpeed;

    [HideInInspector]
    public Vector3 OutputOffset;

    public void StartShake(Quaternion OrlRotation , float Time)
    {
        StartShake(OrlRotation);
        Invoke("EndShake", Time);
    }

    public void StartShake( Quaternion OrlRotation )
    {
        if (IsOpening)
        {
            return;
        }
        IsOpening = true;
        globalUpdateManager.registerUpdateDg(ShakeMovement);
        InvokeRepeating("ReNewTargetV3", 0, ReNewTargetTime);
        ReNewTargetV3();
    }

    void ReNewTargetV3()
    {
        Vector2 Dir = Random.insideUnitCircle * ReNewTargetDisantce;
        TargetV3 = OrlRotation * Dir;
    }
    void ShakeMovement()
    {
        OutputOffset = Vector3.Lerp(OutputOffset, TargetV3, Time.deltaTime * ShakeMovementSpeed);
    }

    void BackToOrlPos()
    {
        TargetV3 = new Vector3();
        Invoke("ResetShake", (Vector3.Distance(OutputOffset, TargetV3) / ShakeMovementSpeed) * 1.5f);
    }

    public void EndShake()
    {
        if (!IsOpening)
        {
            return;
        }
        IsOpening = false;
        BackToOrlPos();
        CancelInvoke("ReNewTargetV3");
    }

    void ResetShake()
    {
        globalUpdateManager.UnregisterUpdateDg(ShakeMovement);
        CancelInvoke();
        OutputOffset = TargetV3;
        OrlRotation = Quaternion.identity;
    }
}
