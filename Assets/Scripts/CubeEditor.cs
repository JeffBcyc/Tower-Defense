using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    Waypoint waypointLocation;

    private void Awake()
    {
        waypointLocation = GetComponent<Waypoint>();    
    }
    


    // Update is called once per frame
    void Update()
    {
        UpdatePos();
        UpdateLabel();
    }

    private void UpdatePos()
    {
        Vector3 x = new Vector3(
            waypointLocation.gridPos().x * waypointLocation.gridScale(),
            0,
            waypointLocation.gridPos().y * waypointLocation.gridScale()
            );
        waypointLocation.transform.position = x;
        
    }

    private void UpdateLabel()
    {
        TextMesh _cubePosition = GetComponentInChildren<TextMesh>();
        string a;
        a = waypointLocation.gridText();
        _cubePosition.text = a;
        gameObject.name = waypointLocation.gridText();
    }



}
