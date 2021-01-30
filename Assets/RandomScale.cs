using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    void Start()
    {
        float RandomSize = Random.Range(1, 4);
        transform.localScale = new Vector3(RandomSize, RandomSize, RandomSize);
    }

}
