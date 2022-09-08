using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Heuristics
{
#pragma warning disable IDE0060 // Remove unused parameter
    public static float NullHeuristic(MapGrid grid, Vector2Int position)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        return 0f;
    }

    public static float BuildingHeuristic(MapGrid grid, Vector2Int position)
    {
        if (grid.HasGridTile(position) && grid.GetGridTile(position).Occupied)
        {
            return grid.GetGridTile(position).OccupiedTower.GetComponent<ABuilding>().Health;
        }
        return 0f;
    }
}
