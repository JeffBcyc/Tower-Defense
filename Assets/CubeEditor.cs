using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    private void Awake()
    {
        Waypoint waypoint = GetComponent<Waypoint>();    
    }
    


    // Update is called once per frame
    void Update()
    {
        UpdatePos();
        UpdateLabel();
    }

    private void UpdatePos()
    {
        Vector3Int newCubePos = new Vector3Int(
            newCubePos.x = W   


            );
    }

    private void UpdateLabel()
    {
        string _textLabel = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        TextMesh _cubePosition = _cubePosition = GetComponentInChildren<TextMesh>();
        _cubePosition.text = _textLabel;
        gameObject.name = _textLabel;
    }
}
