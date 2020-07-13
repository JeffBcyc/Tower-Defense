using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    List<Waypoint> travel = new List<Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        travel = pathfinder.GetPath();
        StartCoroutine(EnemyPatrolPath());
        // the execution will revist there after the code meets yield return new ...
        // it comes back here to execute next line
        // when the rest execution continues for 0.5 seconds it goes back to EnemyPatrolPath Method.
    }

    IEnumerator EnemyPatrolPath()
    {
        foreach (Waypoint waypoint in travel)
        {
            
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(0.5f);
            // ode will stop executing after the first round here
            // then it goes back to the start method to execute whats left
            // after 0.5 seconds it comes back here after 0.5seconds to continue
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
