using System;
using System.Collections.Generic;

public static class Pathfinder
{
    public static List<PathCell> GetPath(IPathGrid grid, PathCell start, PathCell target)
    {
        List<PathCell> path = new List<PathCell>();
        List<PathCell> openSet = new List<PathCell>();
        List<PathCell> closedSet = new List<PathCell>();

        start.G = 0;
        start.H = grid.GetDistanceBetween(start, target);
        start.F = start.G + start.H;

        openSet.Add(start);

        while (openSet.Count > 0)
        {
            PathCell current = openSet[0];
            current = LowestFScore(current, openSet);
            
            if (current.Equals(target))
            {
                return ReconstructPath(current);
            }

            openSet.Remove(current);
            closedSet.Add(current);

            foreach (PathCell neighbor in grid.GetNeighbors(current))
            {
                if (closedSet.Contains(neighbor) || !grid.IsWalkable(neighbor))
                {
                    continue;
                }

                if (current.G + 1 < neighbor.G || !openSet.Contains(neighbor))
                {
                    neighbor.Parent = current;
                    neighbor.G = current.G + 1;
                    neighbor.H = grid.GetDistanceBetween(neighbor, target);
                    neighbor.F = neighbor.G + neighbor.H;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        return path;
    }

    private static PathCell LowestFScore(PathCell current, List<PathCell> set)
    {
        foreach (var candidate in set)
        {
            if (candidate.F < current.F ||
                candidate.F == current.F && candidate.H < current.H)
            {
                current = candidate;
            }
        }
        return current;
    }

    private static List<PathCell> ReconstructPath(PathCell cell)
    {
        List<PathCell> path = new List<PathCell>() { cell };

        while (cell.Parent != null)
        {
            cell = cell.Parent;
            path.Add(cell);
        }

        path.Reverse();
        path.RemoveAt(0);
        return path;
    }
}