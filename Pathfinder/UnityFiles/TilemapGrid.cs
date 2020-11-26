using System;
using System.Collections;
using System.Collections.Generic;


public class TilemapGrid : IGrid
{
    private char[,] tilemap;

    public TilemapGrid(char [,] tilemap)
    {
        this.tilemap = tilemap;
    }

    #region Methods
    public bool IsWalkable(Cell cell)
    {
        if (cell.X < 0 || cell.Y < 0) return false;
        if (cell.X > 9 || cell.Y > 9) return false;
        return tilemap[cell.Y, cell.X] == '.' || tilemap[cell.Y, cell.X] == 'T';
    }

    public List<Cell> GetNeighbors(Cell cell)
    {
        return new List<Cell>()
        {
            new TilemapCell(cell.X, cell.Y + 1, cell.Z), // north
            new TilemapCell(cell.X, cell.Y - 1, cell.Z), // south
            new TilemapCell(cell.X + 1, cell.Y, cell.Z), // east
            new TilemapCell(cell.X - 1, cell.Y, cell.Z), // west
            new TilemapCell(cell.X + 1, cell.Y + 1, cell.Z), // north-east
            new TilemapCell(cell.X + 1, cell.Y - 1, cell.Z), // south-east
            new TilemapCell(cell.X - 1, cell.Y + 1, cell.Z), // north-west
            new TilemapCell(cell.X - 1, cell.Y - 1, cell.Z), // south-west
        };
    }

    public uint GetDistanceBetween(Cell start, Cell target)
    {
        return (uint)(Math.Abs(target.X - start.X) + Math.Abs(target.Y - start.Y));
    }
    #endregion
}