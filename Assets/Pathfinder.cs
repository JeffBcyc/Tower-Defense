using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> path = new Queue<Waypoint>();
    bool isRunning = true;


    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    [SerializeField] Waypoint startWayping;
    [SerializeField] Waypoint endWayping;


    // Start is called before the first frame update
    void Start()
    {
        LoadWaypoints();
        UpdateWaypingColor();
        Pathfind();
        //ExploreNeighbour(startWayping);
    }

    private void Pathfind()
    {
        path.Enqueue(startWayping);

        while (path.Count > 0 && isRunning)
        {
            Waypoint searchCentre = path.Dequeue();
            print("Searching for " + searchCentre);
            HalfIfEndFound(searchCentre);
            ExploreNeighbour(searchCentre);
        }

    }

    private void HalfIfEndFound(Waypoint searchCentre)
    {
        if (searchCentre == endWayping)
        {
            print("Found!");
            isRunning = false;
        }
    }

    private void ExploreNeighbour(Waypoint searchCentre)
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int gridToExplore = direction + searchCentre.gridPos();
            try
            {
                if (! grid[gridToExplore].isExplored)
                {
                    path.Enqueue(grid[gridToExplore]);
                    print(grid[gridToExplore] + " added to Queue");
                    grid[gridToExplore].SetWaypointColor(Color.blue);
                    grid[gridToExplore].isExplored = true;
                }
            }
            catch
            {
                //todo nothing
            }
        }
    }

    private void LoadWaypoints()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint wayping in waypoints)
        {
            if (grid.ContainsKey(wayping.gridPos()))
            {
                Debug.LogWarning("Waypoint " + wayping + " already exists.");
            } else
            {
                grid.Add(wayping.gridPos(), wayping);
                wayping.SetWaypointColor(Color.black);
            }
        }

        print(grid.Count + " waypoints loaded");

    }




    private void UpdateWaypingColor()
    {
        startWayping.SetWaypointColor(Color.white);
        startWayping.isExplored = true;
        endWayping.SetWaypointColor(Color.white);
    }



}
