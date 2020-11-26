using System;

public abstract class PathCell : IEquatable<PathCell>
{
    #region Properties
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public int Z { get; set; } = 0;

    public uint F { get; set; } = uint.MaxValue;
    public uint G { get; set; } = uint.MaxValue;
    public uint H { get; set; } = uint.MaxValue;

    public PathCell Parent { get; set; } = null;
    #endregion

    #region Abstract methods
    public abstract bool Equals(PathCell other);
    #endregion
}