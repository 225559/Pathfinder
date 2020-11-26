using System;

public class TilemapCell : Cell
{
    public TilemapCell(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override bool Equals(Cell other)
    {
        if (other == null)
        {
            throw new ArgumentNullException();
        }
        return other.X == X && other.Y == Y && Z == Z;
    }
}