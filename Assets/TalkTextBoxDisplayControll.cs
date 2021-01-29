using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkTextBoxDisplayControll : SingletonMonoBehavior<TalkTextBoxDisplayControll>
{
    [SerializeField]
    Text TalkText;

    [SerializeField]
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

    // Start is called before the first frame update
    void Start()
    {
        TalkText.text = "";
        TextShowUpSpeed = 0.1f;
        StartTalking("Noki39 was not an imposter.");
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
