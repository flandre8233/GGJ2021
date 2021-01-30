using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsViewPainter : SingletonMonoBehavior<PartsViewPainter>
{

    Dictionary<int, PartsPaintDataBase> PainterDictionary;

    [SerializeField]
    PartsPaintDataBase CrewSprites;
    [SerializeField]
    PartsPaintDataBase CannonSprites;
    [SerializeField]
    PartsPaintDataBase DormSprites;
    [SerializeField]
    PartsPaintDataBase LeftEngineSprites;
    [SerializeField]
    PartsPaintDataBase LeftWingSprite;
    [SerializeField]
    PartsPaintDataBase MainBoosterSprite;
    [SerializeField]
    PartsPaintDataBase RightAmmuntionSprite;
    [SerializeField]
    PartsPaintDataBase RightWingPointSprite;
    [SerializeField]
    PartsPaintDataBase RightWingBoosterSprite;

    private void Start()
    {
        print("Start PainterDictionary");
        PainterDictionary = new Dictionary<int, PartsPaintDataBase>();
        PainterDictionary.Add(0, CrewSprites);
        PainterDictionary.Add(1, CannonSprites);
        PainterDictionary.Add(2, DormSprites);
        PainterDictionary.Add(3, LeftEngineSprites);
        PainterDictionary.Add(4, LeftWingSprite);
        PainterDictionary.Add(5, MainBoosterSprite);
        PainterDictionary.Add(6, RightAmmuntionSprite);
        PainterDictionary.Add(7, RightWingPointSprite);
        PainterDictionary.Add(8, RightWingBoosterSprite);
    }

    public Sprite GetNewPaint(int PartsID, int BelongBy)
    {

        print("GetNewPaint : " + PartsID + "  " + BelongBy);
        if (PainterDictionary == null)
        {
            Start();
        }
        return PainterDictionary[PartsID].Sprites[BelongBy];
    }
}
