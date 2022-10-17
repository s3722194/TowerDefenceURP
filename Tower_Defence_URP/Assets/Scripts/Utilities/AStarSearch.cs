using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AStarSearch
{
    public static List<Vector2Int> Search(MapGrid grid, Vector2Int startPos, Vector2Int endPos,
        bool goThroughBuildings = false, bool ignoreBuildings = false, bool allowDiagonal = false)
    {
        Node node = new Node(startPos, cost: 1);
        if (IsGoalState(node, endPos))
        {
            return new List<Vector2Int> { startPos };
        }

        PriorityQueue<Node> frontier = new PriorityQueue<Node>();
        HashSet<Vector2Int> explored = new HashSet<Vector2Int>();

        frontier.Push(node, 0);
        while (true)
        {
            if (frontier.Count == 0)
            {
                return new List<Vector2Int>();
            }
            node = frontier.Pop();
            if (IsGoalState(node, endPos))
            {
                return GetSolution(node);
            }
            explored.Add(node.Position);
            List<Vector2Int> successors = GetSuccessors(grid, node, goThroughBuildings, allowDiagonal);
            foreach (Vector2Int pos in successors)
            {
                Node child = new Node(pos, node);
                if (!explored.Contains(child.Position))
                {
                    float cost = child.GetPathCost() + Heuristics.DistanceHeuristic(grid, child.Position, endPos);
                    frontier.Update(child, cost);
                }
            }
        }
    }

    public static bool GetPathExists(MapGrid grid, Vector2Int startPos, Vector2Int endPos, List<Vector2Int> exclusions, bool allowDiagonal = false)
    {
        if (exclusions.Contains(startPos))
        {
            return false;
        }
        if (startPos.Equals(endPos))
        {
            return true;
        }

        Queue<Vector2Int> frontier = new Queue<Vector2Int>();
        HashSet<Vector2Int> explored = new HashSet<Vector2Int>();

        frontier.Enqueue(startPos);
        while (true)
        {
            if (frontier.Count == 0)
            {
                return false;
            }
            Vector2Int currentPos = frontier.Dequeue();
            if (currentPos.Equals(endPos))
            {
                return true;
            }
            explored.Add(currentPos);
            List<Vector2Int> successors = GetSuccessors(grid, currentPos, allowDiagonal);
            foreach (Vector2Int pos in successors)
            {
                if (!explored.Contains(pos) && !exclusions.Contains(pos) && !frontier.Contains(pos))
                {
                    frontier.Enqueue(pos);
                }
            }
        }
    }

    public static bool IsGoalState(Node node, Vector2Int endPos)
    {
        return node.Position.Equals(endPos);
    }

    private static List<Vector2Int> GetSolution(Node node)
    {
        Node curNode = node;
        List<Vector2Int> path = new List<Vector2Int>();
        while (curNode != null)
        {
            path.Add(curNode.Position);
            curNode = curNode.Parent;
        }
        path.Reverse();
        return path;
    }

    private static List<Vector2Int> GetSuccessors(MapGrid grid, Node node, bool goThroughBuildings, bool allowDiagonal)
    {
        List<Vector2Int> successors = new List<Vector2Int>();
        Vector2Int pos;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                // allowDiagonal, and clear central pos
                if (i == 0 && j == 0)
                {
                    continue;
                }
                if ((i+j) % 2 == 0 && !allowDiagonal)
                {
                    continue;
                }
                // Remove pos if there is no tile there
                pos = new Vector2Int(node.Position.x+i, node.Position.y+j);
                try
                {
                    if (!grid.HasGridTile(pos))
                    {
                        continue;
                    }
                    // Remove pos if there is a building there
                    if (grid.GetGridTile(pos).Occupied)
                    {
                        continue;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Debug.LogWarning("Index out of range during A* path creation");
                    continue;
                }

                successors.Add(pos);
            }
        }
        return successors;
    }

    private static List<Vector2Int> GetSuccessors(MapGrid grid, Vector2Int currentPos, bool allowDiagonal)
    {
        List<Vector2Int> successors = new List<Vector2Int>();
        Vector2Int pos;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                // allowDiagonal, and clear central pos
                if (i == 0 && j == 0)
                {
                    continue;
                }
                if ((i + j) % 2 == 0 && !allowDiagonal)
                {
                    continue;
                }
                // Remove pos if there is no tile there
                pos = new Vector2Int(currentPos.x + i, currentPos.y + j);
                try
                {
                    if (!grid.HasGridTile(pos))
                    {
                        continue;
                    }
                    // Remove pos if there is a building there
                    if (grid.GetGridTile(pos).Occupied)
                    {
                        continue;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Debug.LogWarning("Index out of range during BFS path check");
                    continue;
                }

                successors.Add(pos);
            }
        }
        return successors;
    }

    public class Node :IComparable<Node>
    {
        private float pathCost;

        public Vector2Int Position { get; private set; }
        public Node Parent { get; private set; }
        public float Cost { get; private set; }

        public Node(Vector2Int position, Node parent=null, int cost = 0, int pathCost = 0)
        {
            Position = position;
            Parent = parent;
            Cost = cost;
            this.pathCost = pathCost;
        }

        public float GetPathCost()
        {
            if (pathCost != 0)
            {
                return pathCost;
            }
            float total = Cost;
            if (Parent != null)
            {
                total += Parent.GetPathCost();
            }
            pathCost = total;
            return total;
        }

        public float UpdatePathCost()
        {
            float total = Cost;
            if (Parent != null)
            {
                total += Parent.UpdatePathCost();
            }
            pathCost = total;
            return total;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }

        public override bool Equals(object obj) => this.Equals(obj as Node);

        public bool Equals(Node node)
        {
            if (node is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (ReferenceEquals(this, node))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (GetType() != node.GetType())
            {
                return false;
            }

            return node.Position.Equals(Position);
        }

        public static bool operator ==(Node node1, Node node2)
        {
            if (node1 is null)
            {
                if (node2 is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return node1.Equals(node2);
        }

        public static bool operator !=(Node node1, Node node2) => !(node1 == node2);

        public int CompareTo(Node other)
        {
            if (other == null) return 1;

            return pathCost.CompareTo(other.pathCost);
        }

        // Define the is greater than operator.
        public static bool operator >(Node node1, Node node2)
        {
            return node1.CompareTo(node2) > 0;
        }

        // Define the is less than operator.
        public static bool operator <(Node node1, Node node2)
        {
            return node1.CompareTo(node2) < 0;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(Node node1, Node node2)
        {
            return node1.CompareTo(node2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(Node node1, Node node2)
        {
            return node1.CompareTo(node2) <= 0;
        }
    }
}