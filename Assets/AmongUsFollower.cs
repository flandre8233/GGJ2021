using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmongUsFollower : MonoBehaviour
{
    [SerializeField]
    public Transform FollowAt;

    Canvas MyCanvas;

    // Start is called before the first frame update
    void Start()
    {
        MyCanvas = GameObject.FindGameObjectWithTag("DefaultCanvas").GetComponent<Canvas>();
        transform.parent = MyCanvas.transform;
         GetComponent<RectTransform>().anchoredPosition = WorldToCanvasPoint(MyCanvas , FollowAt.position) ;
    }

    private void Update()
    {
        Vector2 MyAnchoredPosition = GetComponent<RectTransform>().anchoredPosition ;
        GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp( MyAnchoredPosition  , WorldToCanvasPoint(MyCanvas , FollowAt.position) , Time.deltaTime ) ;
    }

    public static Vector2 WorldToCanvasPoint(Canvas canvas, Vector3 worldPos)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            Camera.main.WorldToScreenPoint(worldPos), canvas.worldCamera, out pos);
        return pos;
    }
}
