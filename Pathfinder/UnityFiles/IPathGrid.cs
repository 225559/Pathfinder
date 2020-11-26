using System.Collections.Generic;

public interface IPathGrid
{
    bool IsWalkable(PathCell cell);

    List<PathCell> GetNeighbors(PathCell cell);

    uint GetDistanceBetween(PathCell start, PathCell target);
}