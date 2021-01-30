using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // 0 : white
    // 1 : Red 
    // 2 : blue 
    public int Belong;

    Vector3 OrlDir;
    float Speed;
    // Start is called before the first frame update
    void Start()
    {
        tag = "Throw";
        OrlDir = transform.parent.up;
        transform.parent = null;
        gameObject.AddComponent<ThrowMapLimit>();
        gameObject.AddComponent<ThrowCollision>();
        Speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Speed*60 * Time.deltaTime));
        transform.position += OrlDir * Time.deltaTime * Speed;
    }

    private void OnDestroy()
    {
        Destroy(GetComponent<ThrowMapLimit>());
        Destroy(GetComponent<ThrowCollision>());
    }

    public void ReSetThrowing()
    {
        Speed = Random.Range(1f, 7.5f);
        SetRandomOrlDir();
    }

     void SetRandomOrlDir()
    {
        OrlDir = Random.insideUnitCircle.normalized;
    }
}
