using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMapLimit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 35f)
        {
            transform.position = new Vector3((transform.position.x - 5) * -1, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -35f)
        {
            transform.position = new Vector3((transform.position.x + 5) * -1, transform.position.y, transform.position.z);
        }

        if (transform.position.y >= 20f)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y - 2.5f) * -1, transform.position.z);
        }
        if (transform.position.y < -20)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y + 2.5f) * -1, transform.position.z);
        }
    }
}
