using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeSpeeder : MonoBehaviour
{
    [SerializeField]
    float TimeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        setTimeScale();
    }
    void Update()
    {
        setTimeScale();
    }

    void setTimeScale()
    {
        TimeSpeed = Mathf.Clamp(TimeSpeed, 0, 100);
        Time.timeScale = TimeSpeed;
    }
}
