using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint : MonoBehaviour
{

    const int gridSize = 10;
    string textLabel;

    public Vector2 gridPos()
    {
        return new Vector2(
        Mathf.Round(transform.position.x / gridSize) * gridSize,
        Mathf.Round(transform.position.z / gridSize) * gridSize
        );
    }

    public int gridScale()
    {
        return gridSize;
    }

    public string gridText()
    {
        textLabel = gameObject.transform.position.x /gridSize  + "," + gameObject.transform.position.z /gridSize;
        return textLabel;
    }


}
