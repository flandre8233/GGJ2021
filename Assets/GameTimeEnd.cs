using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeEnd : MonoBehaviour
{

    
    [SerializeField]
    GameObject CoreObject;
    [SerializeField]
    float PlayTime;
    // Start is called before the first frame update
    void Start()
    {
        DelayDoEventHandler.Create(ShowUpPowerCore, PlayTime / 2);
        DelayDoEventHandler.Create(Lose, PlayTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowUpPowerCore()
    {
        print("ShowUpPowerCore");
        CoreObject.SetActive(true);
    }

    void Lose()
    {
        print("Lose");
    }
}
