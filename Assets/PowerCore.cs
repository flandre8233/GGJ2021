﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class PowerCore : SingletonMonoBehavior<PowerCore>
{
    bool IsEnd;

    [SerializeField]
    GameObject Wall;

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
    Ship SecondWinner;

    float EntryTime;

    QuaternionLerp AnglesFloatLerp;

    QuaternionLerp AnglesFloatLerpEx1;
    vector3Lerp Vector3Lerp;
    vector3Lerp Vector3LerpEx1;

    [SerializeField]
    Canvas MyCanvas;

    [SerializeField]
    GameObject NormalEndUIText;
    [SerializeField]
    GameObject HiddenEndUIText;

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

    public void RemoveSomeShip(Ship ship)
    {
        CapturedByShip.Remove(ship);
    }

    public void OnCaptureTimeEnd()
    {
        print("OnCaptureTimeEnd");
        if (CapturedByShip.Count < 2)
        {
            if (CapturedByShip.Count == 1)
            {
                if (CapturedByShip[0])
                {
                    print("Normal End");
                    Winner = CapturedByShip[0];
                    Winner.GetComponent<EndGameAnimation>().SetAnimation();

                    AnglesFloatLerp = new QuaternionLerp();
                    AnglesFloatLerp.startLerp(Winner.transform.rotation, Quaternion.Euler(0, 0, -90f), 0.5f);

                    Vector3Lerp = new vector3Lerp();
                    Vector3Lerp.startLerp(Winner.transform.position, new Vector3(-1, -.8f, 0), 0.75f);

                    Invoke("NormalEndProgress2", 2.25f);

                    RedUI.SetActive(false);
                    BlueUI.SetActive(false);
                    Destroy(inputControll.gameObject);
                    List<Throwing> ThrowingList = GameObject.FindGameObjectsWithTag("Throw").Where(x => x.GetComponent<Throwing>()).Select(x => x.GetComponent<Throwing>()).ToList();
                    foreach (var item in ThrowingList)
                    {
                        item.SetFree();
                    }
                }
                else
                {
                    EntryTime = int.MaxValue;
                }


            }

        }
        else
        {
            print("hidden End");

            if (CapturedByShip[0] && CapturedByShip[1])
            {
                Winner = CapturedByShip[0];
                SecondWinner = CapturedByShip[1];
                Winner.GetComponent<EndGameAnimation>().SetAnimation();
                SecondWinner.GetComponent<EndGameAnimation>().SetAnimation();

                AnglesFloatLerp = new QuaternionLerp();
                AnglesFloatLerp.startLerp(Winner.transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f);
                AnglesFloatLerpEx1 = new QuaternionLerp();
                AnglesFloatLerpEx1.startLerp(SecondWinner.transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f);
                Invoke("ResetScale", 0.5f);
                Vector3Lerp = new vector3Lerp();
                Vector3Lerp.startLerp(Winner.transform.position, new Vector3(0.8f, -0.8f, 0), 0.75f);
                Vector3LerpEx1 = new vector3Lerp();
                Vector3LerpEx1.startLerp(SecondWinner.transform.position, new Vector3(-0.8f, -.8f, 0), 0.75f);

                Invoke("HiddenEndProgress2", 2.5f);

                RedUI.SetActive(false);
                BlueUI.SetActive(false);
                Destroy(inputControll.gameObject);
                List<Throwing> ThrowingList = GameObject.FindGameObjectsWithTag("Throw").Where(x => x.GetComponent<Throwing>()).Select(x => x.GetComponent<Throwing>()).ToList();
                foreach (var item in ThrowingList)
                {
                    item.SetFree();
                }
            }
            else
            {
                EntryTime = int.MaxValue;
            }

        }

    }

    void ResetScale()
    {
        SecondWinner.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Update()
    {
        if (GameStarter.instance.InGameStart)
        {
            return;
        }

        if (Time.time - EntryTime >= 10)
        {
            OnCaptureTimeEnd();
            EntryTime = int.MaxValue;
        }
        if (AnglesFloatLerp != null && AnglesFloatLerp.isLerping)
        {
            Winner.transform.rotation = AnglesFloatLerp.update();
        }
        if (AnglesFloatLerpEx1 != null && AnglesFloatLerpEx1.isLerping)
        {
            SecondWinner.transform.rotation = AnglesFloatLerpEx1.update();
        }

        if (Vector3Lerp != null && Vector3Lerp.isLerping)
        {
            Winner.transform.position = Vector3Lerp.update();
        }
        if (Vector3LerpEx1 != null && Vector3LerpEx1.isLerping)
        {
            SecondWinner.transform.position = Vector3LerpEx1.update();
        }

        if (IsEnd && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void NormalEndProgress2()
    {
        SetCameraNotFollow();
        transform.parent = Winner.transform;
        Vector3Lerp = new vector3Lerp();
        Vector3Lerp.startLerp(Winner.transform.position, new Vector3(+200, 2.8f, 0), 20f);
        Invoke("SetNormalEndUIText", 1.5f);
        Invoke("SetENd", 1.5f);
    }

    void HiddenEndProgress2()
    {
        Invoke("SetCameraNotFollow", 3f);
        transform.parent = Winner.transform;
        SecondWinner.transform.parent = Winner.transform;
        Vector3Lerp = new vector3Lerp();
        Vector3Lerp.startLerp(Winner.transform.position, new Vector3(0, 200f, 0), 20f);

        Invoke("SetHiddenEndUIText", 2f);
        Invoke("SetENd", 2f);
        Wall.SetActive(false);

    }

    void SetNormalEndUIText()
    {
        NormalEndUIText.SetActive(true);

    }
    void SetHiddenEndUIText()
    {
        HiddenEndUIText.SetActive(true);

    }

    void SetENd()
    {
        IsEnd = true;
    }

    void SetCameraNotFollow()
    {
        VirtualCamera.enabled = false;
    }

    private void Start()
    {
        EntryTime = int.MaxValue;

    }
    public static Vector2 WorldToCanvasPoint(Canvas canvas, Vector3 worldPos)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            Camera.main.WorldToScreenPoint(worldPos), canvas.worldCamera, out pos);
        return pos;
    }
}
