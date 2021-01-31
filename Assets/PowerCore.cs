using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : SingletonMonoBehavior<PowerCore>
{
    [SerializeField]
    inputControll inputControll;

    [SerializeField]
    GameObject RedUI;
    [SerializeField]
    GameObject BlueUI;

    [SerializeField]
    Cinemachine.CinemachineVirtualCamera VirtualCamera;
    [SerializeField]
    List<Ship> CapturedByShip;
    Ship Winner;

    float EntryTime;

    FloatLerp AnglesFloatLerp;
    vector3Lerp Vector3Lerp;

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
            if (CapturedByShip.Count == 1)
            {
                print("Normal End");
                Winner = CapturedByShip[0];
                Winner.GetComponent<EndGameAnimation>().SetAnimation();

                AnglesFloatLerp = new FloatLerp();
                AnglesFloatLerp.startLerp(Winner.transform.rotation.eulerAngles.z, -90f, 0.5f);

                Vector3Lerp = new vector3Lerp();
                Vector3Lerp.startLerp(Winner.transform.position, new Vector3(-1, 2.8f, 0), 0.75f);

                Invoke("NormalEndProgress2", 2.25f);
            }

        }
        else
        {
            print("hidden End");

        }
        RedUI.SetActive(false);
        BlueUI.SetActive(false);
        Destroy(inputControll.gameObject);
    }

    private void Update()
    {
        if (Time.time - EntryTime >= 5)
        {
            OnCaptureTimeEnd();
            EntryTime = int.MaxValue;
        }
        if (AnglesFloatLerp != null && AnglesFloatLerp.isLerping)
        {
            Winner.transform.rotation = Quaternion.Euler(0, 0, AnglesFloatLerp.update());
        }
        if (Vector3Lerp != null && Vector3Lerp.isLerping)
        {
            Winner.transform.position = Vector3Lerp.update();
        }
    }

    void NormalEndProgress2()
    {
        VirtualCamera.enabled = false;
        transform.parent = Winner.transform;
        Vector3Lerp = new vector3Lerp();
        Vector3Lerp.startLerp(Winner.transform.position, new Vector3(+200, 2.8f, 0), 20f);
    }

    private void Start()
    {
        EntryTime = int.MaxValue;

    }
}
