using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingGameCamera : MonoBehaviour
{
    [SerializeField]
 float margin = 1.5f; // space between screen border and nearest fighter
    [SerializeField]
float marginY = 1.5f; // space between screen border and nearest fighter

private float z0; // coord z of the fighters plane
private float zCam; // camera distance to the fighters plane
private float wScene; // scene width
private float hScene; // scene height
    [SerializeField]

private Transform f1; // fighter1 transform
    [SerializeField]
private Transform f2; // fighter2 transform
private float xL; // left screen X coordinate
private float xR; // right screen X coordinate
private float yU; // up screen Y coordinate
private float yD; // down screen Y coordinate

public void calcScreen(Transform p1, Transform p2)
{
    // Calculates the xL and xR screen coordinates 
    if (p1.position.x < p2.position.x)
    {
        xL = p1.position.x - margin;
        xR = p2.position.x + margin;
    }
    else
    {
        xL = p2.position.x - margin;
        xR = p1.position.x + margin;
    }

    if (p1.position.y < p2.position.y)
    {
        yD = p1.position.y - marginY;
        yU = p2.position.y + marginY;
    }
    else
    {
        yD = p2.position.y - marginY;
        yU = p1.position.y + marginY;
    }
}

public void Start()
{
    // initializes scene size and camera distance
    calcScreen(f1, f2);
    wScene = xR - xL;
    hScene = yU - yD;
    zCam = transform.position.z - z0;
}

public void Update()
{
    Vector3 pos = transform.position;
    calcScreen(f1, f2);
    float width = xR - xL;
    float height = yU - yD;

    if (width > wScene)
    { // if fighters too far adjust camera distance
        pos.z = zCam * width / wScene + z0;
    }
    else if (height > hScene)
    { // if fighters too far adjust camera distance
        pos.z = zCam * height / hScene + z0;
    }

    // centers the camera
    pos.x = (xR + xL) / 2;
    pos.y = (yU + yD) / 2;

    transform.position = pos;
}
}
