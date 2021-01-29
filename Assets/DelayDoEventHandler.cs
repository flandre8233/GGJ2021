using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventHandler();

public class DelayDoEventHandler : MonoBehaviour
{
    float DelayTime;
    EventHandler TimeEndHandler;

    public static DelayDoEventHandler Create(EventHandler Event, float Delay)
    {
        GameObject SpawnObject = new GameObject();
        DelayDoEventHandler Delayer = SpawnObject.AddComponent<DelayDoEventHandler>();
        SpawnObject.name = Delayer.GetType().Name;
        Delayer.TimeEndHandler = Event;
        Delayer.DelayTime = Delay;
        return Delayer;
    }

    private void Start()
    {
        StartCountDownLife();
    }

    void StartCountDownLife()
    {
        Invoke("TryInvokeHandler", DelayTime);
        Invoke("Disconstruct" , DelayTime+0.25f);
    }

    public void TryInvokeHandler()
    {
        if (TimeEndHandler != null)
        {
            TimeEndHandler();
        }
    }

    public void Disconstruct(){
        Destroy(gameObject);
    }
}
