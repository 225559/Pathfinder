using System;
using System.Collections;
using System.Collections.Generic;


public class CustomGrid : IPathGrid
{
    private char[,] tilemap;

    public CustomGrid(char [,] tilemap)
    {
        this.tilemap = tilemap;
    }

    #region Methods
    public bool IsWalkable(PathCell cell)
    {
        if (cell.X < 0 || cell.Y < 0) return false;
        if (cell.X > 9 || cell.Y > 9) return false;
        return tilemap[cell.Y, cell.X] == '.' || tilemap[cell.Y, cell.X] == 'T';
    }

    public List<PathCell> GetNeighbors(PathCell cell)
    {
        return new List<PathCell>()
        {
            new CustomCell(cell.X, cell.Y + 1, cell.Z), // north
            new CustomCell(cell.X, cell.Y - 1, cell.Z), // south
            new CustomCell(cell.X + 1, cell.Y, cell.Z), // east
            new CustomCell(cell.X - 1, cell.Y, cell.Z), // west
            new CustomCell(cell.X + 1, cell.Y + 1, cell.Z), // north-east
            new CustomCell(cell.X + 1, cell.Y - 1, cell.Z), // south-east
            new CustomCell(cell.X - 1, cell.Y + 1, cell.Z), // north-west
            new CustomCell(cell.X - 1, cell.Y - 1, cell.Z), // south-west
        };
    }

    public uint GetDistanceBetween(PathCell start, PathCell target)
    {
        return (uint)(Math.Abs(target.X - start.X) + Math.Abs(target.Y - start.Y));
    }
    #endregion
}