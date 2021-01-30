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
        OrlDir = transform.parent.up;
        transform.parent = null;
        gameObject.AddComponent<ThrowMapLimit>();
        gameObject.AddComponent<ThrowCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 540 * Time.deltaTime));
        transform.position += OrlDir * Time.deltaTime * 5;
    }

    private void OnDestroy() {
        Destroy( GetComponent<ThrowMapLimit>() );
        Destroy( GetComponent<ThrowCollision>() );
    }
}
