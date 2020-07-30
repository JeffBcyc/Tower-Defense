using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    Waypoint _waypointLocation;

    private void Awake()
    {
        UpdateLabel();
        waypointLocation = GetComponent<Waypoint>();    
        print("I'm using visual studio code, valla");
        print("this editor is basically telling me my code is shit");
    }
    


    // Update is called once per frame
    void Update()
    {
        UpdatePos();
    }


    private void UpdatePos()
    {
        Vector3 x = new Vector3(
            waypointLocation.gridPos().x,
            0,
            waypointLocation.gridPos().y
            );
        waypointLocation.transform.position = x;
        
    }

    private void UpdateLabel()
    {
        TextMesh _cubePosition = GetComponentInChildren<TextMesh>();
        _cubePosition.text = waypointLocation.gridText();
        gameObject.name = waypointLocation.gridText();
    }
}
