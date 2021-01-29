using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmongUsEasterEgg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject AmongUsPrefab = Resources.Load<GameObject>("WasNot");
        GameObject Spawnobject = Instantiate(AmongUsPrefab);
        Spawnobject.GetComponent<AmongUsFollower>().FollowAt = transform;

        Destroy(Spawnobject, 3f);
    }
}
