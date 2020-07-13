using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint>que= new Queue<Waypoint>();
    bool isRunning = true;
    List<Waypoint> path = new List<Waypoint>();
       

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    Waypoint searchCentre;

    [SerializeField] Waypoint startWayping = null;
    [SerializeField] Waypoint endWayping = null;



    public List<Waypoint> GetPath()
    {
        LoadWaypoints();
        Pathfind();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWayping);
        Waypoint previousWaypoint = endWayping.searchedFrom;
        while (previousWaypoint != startWayping)
        {
            path.Add(previousWaypoint);
            previousWaypoint = previousWaypoint.searchedFrom;
        }
        path.Add(startWayping);
        path.Reverse();
    }

    private void Pathfind()
    {
        que.Enqueue(startWayping);

        while (que.Count > 0 && isRunning)
        {
            searchCentre = que.Dequeue();
            HalfIfEndFound();
            ExploreNeighbour();
        }

    }

    private void HalfIfEndFound()
    {
        if (searchCentre == endWayping)
        {
            endWayping.isExplored = false;
            isRunning = false;

        }
    }

    private void ExploreNeighbour()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int gridToExplore = direction + searchCentre.gridPos();
            try
            {
                if (!grid[gridToExplore].isExplored )//|| path.Contains(grid[gridToExplore]))
                {
                    que.Enqueue(grid[gridToExplore]);
                    grid[gridToExplore].isExplored = true;
                    grid[gridToExplore].searchedFrom = searchCentre;
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
            }
        }


    }


}
