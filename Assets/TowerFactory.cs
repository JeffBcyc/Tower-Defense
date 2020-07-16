using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab = null;

    [SerializeField] Transform towerStore;

    Queue<Tower> towerQueue = new Queue<Tower>();

    int nofTower = 0;

    public void BuiltATower(Waypoint baseWaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        nofTower = towers.Length;
        if (nofTower < towerLimit)
        {
            Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position + new Vector3(0, 10f, 0), Quaternion.identity);
            newTower.transform.parent = towerStore;
            towerQueue.Enqueue(newTower);
            baseWaypoint.isPlacable = false;
            newTower.baseWaypoint = baseWaypoint;
        } else
        {
            print("Tower Limit Hit, moving the oldest tower");
            Tower oldTower = towerQueue.Dequeue();
            oldTower.baseWaypoint.isPlacable = true;
            oldTower.transform.position = baseWaypoint.transform.position + new Vector3(0,10f,0);
            baseWaypoint.isPlacable = false;
            oldTower.baseWaypoint = baseWaypoint;
            towerQueue.Enqueue(oldTower);
        }
    }


}
