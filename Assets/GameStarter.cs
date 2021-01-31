using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : SingletonMonoBehavior<GameStarter>
{
    public bool InGameStart;

    [SerializeField]
    GameObject InputControll;

    [SerializeField]
    GameObject Core;
    [SerializeField]
    GameObject Exp;

    [SerializeField]
    GameObject RedShip;
    [SerializeField]
    GameObject BlueShip;
    [SerializeField]
    Animator RedShipAnimator;
    [SerializeField]
    Animator BlueShipAnimator;

    [SerializeField]
    vector3Lerp RedVector3Lerp;
    [SerializeField]
    vector3Lerp BlueVector3Lerp;
    QuaternionLerp RedQuaternionLerp;
    QuaternionLerp BlueQuaternionLerp;

    public void OnGameStart()
    {
        print("OnGameStart");
        SetCoreDisable();
        Invoke("BlueShipExit", 3f);
        Invoke("RedShipExit", 3f);

        Invoke("RedShipChangeScale", 4.3f);

        Invoke("AnimationEnd", 5f);

    }

    void SetCoreDisable()
    {
        Invoke("SpawnExp", 0.3f);
        Invoke("SpawnExp", 0.9f);
        Invoke("SpawnExp", 1.25f);
        Invoke("SpawnExp", 0.6f);
        Invoke("SpawnExp", 0.9f);
        Invoke("SpawnExp", 1.2f);
        Invoke("SpawnExp", .9f);
        Invoke("SpawnExp", 0.36f);
        Invoke("SpawnExp", 1.5f);
        Invoke("SpawnExp", 3f);
        Invoke("SetCore", 3.1f);
    }

    void RedShipExit()
    {
        RedShipAnimator.speed = 1;
        RedVector3Lerp = new vector3Lerp();
        RedVector3Lerp.startLerp(RedShip.transform.position, new Vector3(-10, 5, 0), 1f);
        RedQuaternionLerp = new QuaternionLerp();
        RedQuaternionLerp.startLerp(RedShip.transform.rotation, Quaternion.Euler(0, 0, 135), 1.25f);
    }

    void RedShipChangeScale()
    {
        RedShip.transform.localScale = new Vector3(1, 1, 1);
    }
    void BlueShipExit()
    {
        BlueShipAnimator.speed = 1;
        BlueVector3Lerp = new vector3Lerp();
        BlueVector3Lerp.startLerp(BlueShip.transform.position, new Vector3(10, -5, 0), 1f);
        BlueQuaternionLerp = new QuaternionLerp();
        BlueQuaternionLerp.startLerp(BlueShip.transform.rotation, Quaternion.Euler(0, 0, -135), 1.25f);

    }

    void SpawnExp()
    {
        GameObject ExplosionPrefab = Resources.Load<GameObject>("Explosion");
        Vector3 SpawnPosition = Core.transform.position;
        Vector3 Rand = Random.insideUnitCircle * 2f;
        SpawnPosition += Rand;
        Instantiate(ExplosionPrefab, SpawnPosition, GetRandomAngles());
    }

    Quaternion GetRandomAngles()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360f));
    }

    void AnimationEnd()
    {
        InputControll.SetActive(true);
        InGameStart = false;
        GameTimeEnd.instance.StartTimeDown();
        OnGameStarterAnimationEND();
    }

    void SetCore()
    {
        Core.SetActive(false);
    }

    private void Start()
    {
        RedShipAnimator.speed = 0;
        BlueShipAnimator.speed = 0;
        InGameStart = true;
    }

    private void Update()
    {
        if (RedVector3Lerp != null && RedVector3Lerp.isLerping)
        {
            RedShip.transform.position = RedVector3Lerp.update();
        }
        if (BlueVector3Lerp != null && BlueVector3Lerp.isLerping)
        {
            BlueShip.transform.position = BlueVector3Lerp.update();
        }
        if (RedQuaternionLerp != null && RedQuaternionLerp.isLerping)
        {
            RedShip.transform.rotation = RedQuaternionLerp.update();
        }
        if (BlueQuaternionLerp != null && BlueQuaternionLerp.isLerping)
        {
            BlueShip.transform.rotation = BlueQuaternionLerp.update();
        }
    }

    public void OnGameStarterAnimationEND()
    {
        UIControl.instance.InitAllStyleUI(UIStyle.AMONG_US, PlayerType.Red);
        UIControl.instance.InitAllStyleUI(UIStyle.Default, PlayerType.Blue);
    }

}
