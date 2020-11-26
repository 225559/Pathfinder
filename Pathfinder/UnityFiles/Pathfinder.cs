using System;
using System.Collections.Generic;

public static class Pathfinder
{
    public static List<Cell> GetWalkablePath(IGrid grid, Cell start, Cell target)
    {
        List<Cell> path = new List<Cell>();
        List<Cell> openSet = new List<Cell>();
        List<Cell> closedSet = new List<Cell>();

        start.G = 0;
        start.H = grid.GetDistanceBetween(start, target);
        start.F = start.G + start.H;

        openSet.Add(start);

        while (openSet.Count > 0)
        {
            Cell current = openSet[0];
            current = LowestFScore(current, openSet);
            
            if (current.Equals(target))
            {
                return ReconstructPath(current);
            }

            openSet.Remove(current);
            closedSet.Add(current);

            foreach (Cell neighbor in grid.GetNeighbors(current))
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

    private static Cell LowestFScore(Cell current, List<Cell> set)
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

    private static List<Cell> ReconstructPath(Cell cell)
    {
        List<Cell> path = new List<Cell>() { cell };

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