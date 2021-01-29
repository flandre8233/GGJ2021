using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class globalUpdateManager : SingletonMonoBehavior<globalUpdateManager> {
    public static float deltaTime;

    public delegate void updateDelegate();

    public updateDelegate globalUpdateDg;
    void updateDeltaTimeData() {
        deltaTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
        updateDeltaTimeData();
        if (globalUpdateDg != null) {
            globalUpdateDg.Invoke();
        }
    }

    /// <summary>
    /// 把function註冊在每幀執行的delegate裡
    /// </summary>
    public static void registerUpdateDg(updateDelegate obj) {
       instance.globalUpdateDg += obj;
    }
    /// <summary>
    /// 取消function在每幀執行的delegate的註冊
    /// </summary>
    public static void UnregisterUpdateDg(updateDelegate obj) {
        instance.globalUpdateDg -= obj;
    }

    public static void ClearDelegate(ref updateDelegate delg) {
        System.Delegate[] delegates = delg.GetInvocationList();
        foreach (System.Delegate d in delegates) {
            delg -= (updateDelegate)d;
        }
    }
}
