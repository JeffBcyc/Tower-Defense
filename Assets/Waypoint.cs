using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    const int gridSize = 10;
    string textLabel;

    public Vector2Int gridPos()
    {

        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
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


    public void SetWaypointColor(Color color)
    {
        MeshRenderer waypointMesh = transform.Find("Top").GetComponent<MeshRenderer>();
        waypointMesh.material.color = color;
    }

}
