using System.Numerics;

namespace AdventOfCode._2023.Day10;

public static class Direction
{
    public static readonly Complex North = -Complex.ImaginaryOne;
    public static readonly Complex South = Complex.ImaginaryOne;
    public static readonly Complex West = -Complex.One;
    public static readonly Complex East = Complex.One;
    public static readonly Complex[] All = [North, East, South, West];
    public static readonly Complex[] None = [];

    public static bool IsNotOppositeDirection(this Complex direction, Complex otherDirection)
        => direction != otherDirection.OppositeDirection();

    public static Complex OppositeDirection(this Complex direction)
        => -direction;
}