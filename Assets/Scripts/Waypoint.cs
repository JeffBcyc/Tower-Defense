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
    [SerializeField] Tower tower = null;
    [SerializeField] GameObject towerParent;

    //private void Update()
    //{
    //    if (isExplored && (! (searchedFrom == null)))
    //    {
    //        SetWaypointColor(Color.blue);
    //    }
    //}

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


    //public void SetWaypointColor(Color color)
    //{
    //    MeshRenderer waypointMesh = transform.Find("Top").GetComponent<MeshRenderer>();
    //    //waypointMesh.material.color = color;
    //}


    private void OnMouseDown()
    {
        if (isPlacable)
        {
            PlaceATower(gameObject.transform);

        } else
        {
            print("cant place here!");
        }
    }

    void PlaceATower(Transform cube)
    {
        Tower newTower = Instantiate(tower, transform.position + new Vector3(0,10f,0), Quaternion.identity);
        newTower.transform.parent = towerParent.transform;
        isPlacable = false;
    }

}
