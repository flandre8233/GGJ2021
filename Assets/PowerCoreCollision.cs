﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCoreCollision : MonoBehaviour
{
    [SerializeField]
    PowerCore Core;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Core")
        {
            Ship TouchedShip = other.GetComponent<ShipCore>().ParentShip;
            Core.OnCapturedEnter(TouchedShip);
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Core")
        {
            Ship TouchedShip = other.GetComponent<ShipCore>().ParentShip;
            Core.OnCapturedExit(TouchedShip);
        }
    }
}
