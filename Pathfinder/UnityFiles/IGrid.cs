using System.Collections.Generic;

public interface IGrid
{
    bool IsWalkable(Cell cell);

    List<Cell> GetNeighbors(Cell cell);

    uint GetDistanceBetween(Cell start, Cell target);
}