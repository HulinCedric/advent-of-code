using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day18;

public class Lagoon(IEnumerable<Coordinate> coordinates)
{
    public long Area()
    {
        var boundaryPoints = BoundaryPoints();

        var interiorPoints = InteriorPoints_Internal(boundaryPoints);

        return boundaryPoints + interiorPoints;
    }

    private long InteriorPoints_Internal(long boundaryPoints)
        => InnerArea() - boundaryPoints / 2 + 1;

    public long InteriorPoints()
        => InteriorPoints_Internal(BoundaryPoints());

    /// <summary>
    ///     Boundary points are the number of points on the polygon's boundary.
    ///     This is also known as the perimeter.
    /// </summary>
    public long BoundaryPoints()
        => Edges()
            .Select(edge => (edge.A - edge.B).Length)
            .Sum();

    /// <summary>
    ///     Calculate the area of the polygon using the shoelace formula.
    /// </summary>
    /// <seealso href="https://en.wikipedia.org/wiki/Shoelace_formula" />
    private long InnerArea()
    {
        var shoelaces = Edges()
            .Select(edge => edge.A.Y * edge.B.X - edge.A.X * edge.B.Y);

        return Math.Abs(shoelaces.Sum()) / 2;
    }

    private IEnumerable<(Coordinate A, Coordinate B)> Edges()
        => coordinates.Zip(coordinates.Skip(1));
}