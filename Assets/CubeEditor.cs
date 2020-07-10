using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{

    [Range (1f, 20f)][SerializeField] int gridSize = 6;

    TextMesh _cubePosition;


    // Update is called once per frame
    void Update()
    {

        Vector3 snapPos;
        snapPos.x = Mathf.Round(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.Round(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        string _textLabel = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        // test
        _cubePosition = GetComponentInChildren<TextMesh>();
        _cubePosition.text = _textLabel;

        gameObject.name = _textLabel;

    }
}
