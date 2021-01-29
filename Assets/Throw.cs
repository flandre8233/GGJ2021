using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    Vector3 OrlDir;
    // Start is called before the first frame update
    void Start()
    {
        tag = "Throw";
        OrlDir = transform.up;
        transform.parent = null;
        GetComponent<Collider2D>().isTrigger = true;
        DelayDoEventHandler.Create(ResetCollider, 0.5f);

        if (GetComponent<Parts>().Egg)
        {
            gameObject.AddComponent<AmongUsEasterEgg>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 540 * Time.deltaTime));
        transform.position += OrlDir * Time.deltaTime * 5;
    }

    void ResetCollider()
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
