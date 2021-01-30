using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowUI : MonoBehaviour
{
    public Transform followTarget;
    public Canvas canvas;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("DefaultCanvas").GetComponent<Canvas>();
        transform.parent = canvas.transform;
        GetComponent<RectTransform>().anchoredPosition = WorldToCanvasPoint(canvas , followTarget.position) ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MyAnchoredPosition = GetComponent<RectTransform>().anchoredPosition ;
        GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp( MyAnchoredPosition  , WorldToCanvasPoint(canvas , followTarget.position) , Time.deltaTime ) ;
    }

    public static Vector2 WorldToCanvasPoint(Canvas canvas, Vector3 worldPos)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            Camera.main.WorldToScreenPoint(worldPos), canvas.worldCamera, out pos);
        return pos;
    }
}
