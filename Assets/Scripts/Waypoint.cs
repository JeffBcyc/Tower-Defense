using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    const int gridSize = 10;
    string textLabel;
    public Waypoint searchedFrom;
    public bool isPlacable = true;
    //[SerializeField] Tower tower = null;
    [SerializeField] GameObject towerParent;

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


    private void OnMouseDown()
    {
        if (isPlacable)
        {
            FindObjectOfType<TowerFactory>().BuiltATower(this);
        } else
        {
            print("cant place here!");
        }
    }

}
