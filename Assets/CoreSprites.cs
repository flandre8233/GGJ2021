using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSprites : MonoBehaviour
{
    [SerializeField]
    Sprite[] Sprites;
    public void SetCoreSpritesBroken(bool IsBroken)
    {
        GetComponent<SpriteRenderer>().sprite = Sprites[IsBroken ? 0 : 1];
    }
}
