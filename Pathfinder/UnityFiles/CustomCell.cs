using System;

public class CustomCell : PathCell
{
    public CustomCell(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override bool Equals(PathCell other)
    {
        if (other == null)
        {
            throw new ArgumentNullException();
        }
        return other.X == X && other.Y == Y && Z == Z;
    }
}