using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Heuristics
{
#pragma warning disable IDE0060 // Remove unused parameter
    public static float NullHeuristic(Grid grid, Vector2Int position)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        return 0f;
    }

    public static float BuildingHeuristic(Grid grid, Vector2Int position)
    {
        if (grid.HasTile(position) && grid.GetTile(position).Occupied)
        {
            return grid.GetTile(position).OccupiedTower.GetComponent<ABuilding>().Health;
        }
        return 0f;
    }
}
