using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : IEnumerable<Vector2Int>
{
    List<Vector2Int> positions;

    public Path(List<Vector2Int> positionList)
    {
        positions = positionList;
    }

    public List<Vector2Int> GetPositions()
    {
        return positions;
    }

    public void UpdatePositions(List<Vector2Int> positionList)
    {
        positions = positionList;
    }

    public Vector2Int GetNextPosition(Vector2Int lastPosition)
    {
        for (int i = 0; i < positions.Count - 1; i++)
        {
            if (positions[i].Equals(lastPosition))
            {
                return positions[i + 1];
            }
        }
        return lastPosition;
    }

    public int GetPositionNumber(Vector2Int position)
    {
        return positions.IndexOf(position);
    }

    public Vector2Int GetStartPosition()
    {
        return positions[0];
    }

    public Vector2Int GetEndPosition()
    {
        return positions[-1];
    }

    public bool IsEndPosition(Vector2Int position)
    {
        return position.Equals(GetEndPosition());
    }

    public Vector2Int CalculateNextPosition(Vector2 point, int positionNumber=0)
    {
        for (int i = positionNumber; i < Count() - 1; i++)
        {
            if (PointExistsOnLineSegment(positions[i], positions[i + 1], point))
            {
                return positions[i + 1];
            }
        }

        // If the point does not lie along the path
        float distance = Mathf.Infinity;
        float tempDist;
        Vector2Int minPosition = positions[positionNumber];
        for (int i = positionNumber; i < Count(); i++)
        {
            tempDist = Vector2.Distance(positions[i], point);
            if (tempDist < distance)
            {
                distance = tempDist;
                minPosition = positions[i];
            }
        }
        return minPosition;
    }

    public static bool PointExistsOnLineSegment(Vector2 a, Vector2 b, Vector2 p, float tolerance = 0.001f)
    {
        var seg = b - a;
        var v = p - a;
        var segLen = seg.magnitude;
        float dot = Vector2.Dot(v, seg / segLen);
        return (dot >= 0f) && (dot <= segLen) && (Mathf.Abs(dot - v.magnitude) <= tolerance);
    }

    public Vector2Int GetNextPosition(int positionCount)
    {
        if (positionCount < positions.Count && positionCount > -1)
        {
            return positions[positionCount + 1];
        }
        else if (positionCount >= positions.Count)
        {
            return positions[-1];
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("Position count must be between 0 and the size of the position list");
        }
    }

    public bool Contains(Vector2Int pos)
    {
        return positions.Contains(pos);
    }

    public IEnumerator<Vector2Int> GetEnumerator()
    {
        return ((IEnumerable<Vector2Int>)positions).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)positions).GetEnumerator();
    }

    public Vector2Int this[int index]
    {
        get => positions[index];
        set => positions[index] = value;
    }

    public int Count()
    {
        return positions.Count;
    }
}
