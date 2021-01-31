using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//掛在Canvas上，控管所有UI的生成和隱藏
public class UIControl : MonoBehaviour
{
    [System.Serializable]
    public struct ui
    {
        public UIType types;
        public GameObject uiImage;
    }
    public Dictionary<PlayerType, Dictionary<UIType, GameObject>> uiDic = new Dictionary<PlayerType, Dictionary<UIType, GameObject>>();
    public List<ui> UIListBlue;
    public List<ui> UIListRed;
    public UIBase uIBase;
    public CanvasGroup StartMenu;

    public bool needInit = true;
    void Awake()
    {
        var tmp1 = new Dictionary<UIType, GameObject>();
        var tmp2 = new Dictionary<UIType, GameObject>();
        foreach (var i in UIListBlue)
        {
            tmp1.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Blue, tmp1);

        foreach (var i in UIListRed)
        {
            tmp2.Add(i.types, i.uiImage);
        }
        uiDic.Add(PlayerType.Red, tmp2);
        REmoveAllUI();
        //needInit = false;
    }

    void Update()
    {
        if (!needInit)
        {
            return;
        }

        if (CheckStart())
        {
            InitAllStyleUI(UIStyle.AMONG_US, PlayerType.Red);
            InitAllStyleUI(UIStyle.Default, PlayerType.Blue);
            StartCoroutine(StartMenuFadeOut());
            GameStarter.instance.OnGameStart();
            needInit = false;
        }
    }

    //增加UI至Canvas
    public void AddRandomUI(UIType uIType, PlayerType player)
    {
        List<UIItem> randomBase = new List<UIItem>();
        foreach (var i in uIBase.GetUIItems(player))
        {
            if (i.uIType == uIType)
            {
                randomBase.Add(i);
            }
        }
        var result = Random.Range(0, randomBase.Count);
        uiDic[player][uIType].GetComponent<Image>().sprite = randomBase[result].uiSprite;
        uiDic[player][uIType].GetComponent<Image>().color = Color.white;
    }

    //增加指定樣式UI
    public void AddStyleUI(UIType uIType, UIStyle uIStyle, PlayerType player)
    {
        foreach (var i in uIBase.GetUIItems(player))
        {
            if (i.uIType == uIType && i.uIStyle == uIStyle)
            {
                uiDic[player][uIType].GetComponent<Image>().sprite = i.uiSprite;
                uiDic[player][uIType].GetComponent<Image>().color = Color.white;
            }
        }
    }

    //生成整套UI
    public void InitAllStyleUI(UIStyle uIStyle, PlayerType player)
    {
        foreach (var i in uIBase.GetUIItems(player))
        {
            if (i.uIStyle == uIStyle)
            {
                uiDic[player][i.uIType].GetComponent<Image>().sprite = i.uiSprite;
                uiDic[player][i.uIType].GetComponent<Image>().color = Color.white;
            }
        }
    }

    //從Canvas隱藏UI
    public void RemoveUI(UIType uIType, PlayerType player)
    {
        Debug.Log(uiDic[player][uIType].name);
        uiDic[player][uIType].GetComponent<Image>().color = Color.clear;
    }

    //隱藏全部UI
    public void REmoveAllUI()
    {
        foreach (var i in UIListBlue)
        {
            i.uiImage.GetComponent<Image>().color = Color.clear;
        }
        foreach (var i in UIListRed)
        {
            i.uiImage.GetComponent<Image>().color = Color.clear;
        }
    }

    //確認雙方按下開始
    public bool CheckStart()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.Alpha0))
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerator StartMenuFadeOut()
    {
        float fadeTime = 2f;
        while(StartMenu.alpha >= 0.01){
            StartMenu.alpha -= Time.deltaTime / fadeTime;
            yield return null;
        }
        StartMenu.alpha = 0;
    }
}
