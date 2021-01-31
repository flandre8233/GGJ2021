using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public bool Attachable = false;
    Vector3 OrlDir;
    float Speed;

    public static Throwing Create(GameObject TargetObject)
    {
        if (TargetObject.GetComponent<Throwing>())
        {
            return TargetObject.GetComponent<Throwing>();
        }
        Throwing Ret = TargetObject.AddComponent<Throwing>();
        Ret.tag = "Throw";
        Ret.gameObject.AddComponent<ThrowCollision>();
        return Ret;
    }

    void CanBeAttach()
    {
        Attachable = true;
    }

    protected virtual void Start()
    {
        DelayDoEventHandler.Create(CanBeAttach, 3);

       
        if (transform.parent)
        {
            OrlDir = transform.parent.up;
        }
        else
        {
            SetRandomOrlDir();
        }
        transform.parent = null;
        gameObject.AddComponent<ThrowMapLimit>();
        Speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Speed * 60 * Time.deltaTime));
        transform.position += OrlDir * Time.deltaTime * Speed;
    }

    private void OnDestroy()
    {
       SetFree();
    }

    public void SetFree(){
         if (GetComponent<ThrowMapLimit>())
        {
            Destroy(GetComponent<ThrowMapLimit>());
        }
        if (GetComponent<ThrowCollision>())
        {
            Destroy(GetComponent<ThrowCollision>());
        }
        tag = "Untagged";
    }

    public void ReSetThrowing()
    {
        Speed = Random.Range(5f, 10f);
        SetRandomOrlDir();
    }

    protected virtual void SetRandomOrlDir()
    {
        OrlDir = Random.insideUnitCircle.normalized;
    }
}
