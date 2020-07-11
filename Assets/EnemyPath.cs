using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyPatrolPath());
        // the execution will revist there after the code meets yield return new ...
        // it comes back here to execute next line
        // when the rest execution continues for 0.5 seconds it goes back to EnemyPatrolPath Method.
        print("Back at start");
    }

    IEnumerator EnemyPatrolPath()
    {
        print("Start Coroutine");
        foreach (Waypoint waypoint in path)
        {
            
            transform.position = waypoint.transform.position;
            print(waypoint.name);
            yield return new WaitForSeconds(0.5f);
            // ode will stop executing after the first round here
            // then it goes back to the start method to execute whats left
            // after 0.5 seconds it comes back here after 0.5seconds to continue
        }

        print("End Coroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
