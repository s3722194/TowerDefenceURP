using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Heuristics
{
#pragma warning disable IDE0060 // Remove unused parameter
    public static float NullHeuristic(MapGrid grid, Vector2Int position, Vector2Int goalPosition)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        return 0f;
    }

    public static float BuildingHeuristic(MapGrid grid, Vector2Int position, Vector2Int goalPosition)
    {
        float score = DistanceHeuristic(grid, position, goalPosition);
        if (grid.HasGridTile(position) && grid.GetGridTile(position).Occupied)
        {
            score += grid.GetGridTile(position).OccupiedTower.GetComponent<ABuilding>().Health;
        }
        return score;
    }

    public static float DistanceHeuristic(MapGrid grid, Vector2Int position, Vector2Int goalPosition)
    {
        return Vector2Int.Distance(position, goalPosition);
    }
}
