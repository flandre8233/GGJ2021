using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : SingletonMonoBehavior<GameStarter>
{
    [SerializeField]
    GameObject InputControll;

    [SerializeField]
    GameObject Core;
    [SerializeField]
    GameObject Exp;

    public void OnGameStart()
    {
        print("OnGameStart");
        SetCoreDisable();
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

        Invoke("AnimationEnd" , 5f);
    }
    void SpawnExp()
    {
        GameObject ExplosionPrefab = Resources.Load<GameObject>("Explosion");
        Vector3 SpawnPosition = Core.transform.position;
        Vector3 Rand = Random.insideUnitCircle * 2f;
        print(Random.insideUnitCircle );
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

    }

}
