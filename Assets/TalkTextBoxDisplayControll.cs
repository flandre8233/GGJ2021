using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkTextBoxDisplayControll : SingletonMonoBehavior<TalkTextBoxDisplayControll>
{
    Text TalkText;

    string TargetText;

    char[] CharArray;
    int NowIndex;

    [SerializeField]
    float TextShowUpSpeed;

    [SerializeField]
    Event OnEndTalk;

    [SerializeField]
    bool InTalking;

    public bool GetIsTalking()
    {
        return InTalking;
    }

protected virtual void Start() {
   TalkText = GetComponent<Text>();
}

    void AddChar()
    {
        if (NowIndex >= CharArray.Length)
        {
            EndTalk();
            return;
        }

        TalkText.text += CharArray[NowIndex];
        NowIndex++;

        Invoke("AddChar", TextShowUpSpeed);
    }

    public void StartTalking(string Talk)
    {
        InTalking = true;
        TargetText = Talk;

        TalkText.text = "";
        NowIndex = 0;
        CharArray = TargetText.ToCharArray();
        CancelInvoke();
        Invoke("AddChar", TextShowUpSpeed);
    }

    public void EndTalk()
    {
        InTalking = false;
    }

    public void SkipTalkingAni()
    {
        CancelInvoke();
        TalkText.text = TargetText;
        EndTalk();
    }

}
