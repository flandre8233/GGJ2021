using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    FloatLerp AnglesFloatLerp;

    FloatLerp AnglesFloatLerpEx1;
    FloatLerp AnglesFloatLerpEx2;
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

                    AnglesFloatLerp = new FloatLerp();
                    AnglesFloatLerp.startLerp(Winner.transform.rotation.eulerAngles.z, -90f, 0.5f);

                    Vector3Lerp = new vector3Lerp();
                    Vector3Lerp.startLerp(Winner.transform.position, new Vector3(-1, 2.8f, 0), 0.75f);

                    Invoke("NormalEndProgress2", 2.25f);
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

                AnglesFloatLerp = new FloatLerp();
                AnglesFloatLerp.startLerp(Winner.transform.rotation.eulerAngles.z, 0, 0.5f);
                AnglesFloatLerpEx1 = new FloatLerp();
                AnglesFloatLerpEx1.startLerp(SecondWinner.transform.rotation.eulerAngles.z, 0, 0.5f);
                AnglesFloatLerpEx2 = new FloatLerp();
                AnglesFloatLerpEx2.startLerp(1, -1, 0.5f);

                Vector3Lerp = new vector3Lerp();
                Vector3Lerp.startLerp(Winner.transform.position, new Vector3(0.8f, 2.8f, 0), 0.75f);
                Vector3LerpEx1 = new vector3Lerp();
                Vector3LerpEx1.startLerp(SecondWinner.transform.position, new Vector3(-0.8f, 2.8f, 0), 0.75f);

                Invoke("HiddenEndProgress2", 2.5f);
            }
            else
            {
                EntryTime = int.MaxValue;
            }


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
        if (AnglesFloatLerpEx1 != null && AnglesFloatLerpEx1.isLerping)
        {
            SecondWinner.transform.rotation = Quaternion.Euler(0, 0, AnglesFloatLerpEx1.update());
        }
        if (AnglesFloatLerpEx2 != null && AnglesFloatLerpEx2.isLerping)
        {
            SecondWinner.transform.localScale = new Vector3(AnglesFloatLerpEx2.update(), 1, 1);
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
