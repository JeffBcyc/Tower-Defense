using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    const int gridSize = 10;


    public Vector2 gridPos()
    {
        return new Vector2Int(
        Mathf.Round(transform.position.x / gridSize) * gridSize,
        Mathf.Round(transform.position.z / gridSize) * gridSize
        );
    }

    public int gridScale()
    {
        return gridSize;
    }

}
