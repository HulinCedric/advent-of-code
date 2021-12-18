using System;
using System.Collections.Generic;

namespace AdventOfCode.Day05;

public record LineOfVent(Coordinate C1, Coordinate C2)
{
    public IEnumerable<Coordinate> Coordinates
        => GetPointsOnLine();

    public bool IsDiagonal45
        => Math.Abs(C1.X - C2.X) == Math.Abs(C1.Y - C2.Y);

    public bool IsHorizontal
        => C1.X != C2.X && C1.Y == C2.Y;

    public bool IsVertical
        => C1.X == C2.X && C1.Y != C2.Y;

    /// <see href="https://en.wikipedia.org/wiki/Bresenham's_line_algorithm" />
    private IEnumerable<Coordinate> GetPointsOnLine()
    {
        var x1 = C1.X;
        var y1 = C1.Y;
        var x2 = C2.X;
        var y2 = C2.Y;

        var steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);
        if (steep)
        {
            var t = x1; // swap x1 and y1
            x1 = y1;
            y1 = t;
            t = x2; // swap x2 and y2
            x2 = y2;
            y2 = t;
        }

        if (x1 > x2)
        {
            var t = x1; // swap x1 and x2
            x1 = x2;
            x2 = t;
            t = y1; // swap y1 and y2
            y1 = y2;
            y2 = t;
        }

        var dx = x2 - x1;
        var dy = Math.Abs(y2 - y1);
        var error = dx / 2;
        var yStep = y1 < y2 ? 1 : -1;
        var y = y1;

        for (var x = x1; x <= x2; x++)
        {
            yield return new Coordinate(steep ? y : x, steep ? x : y);
            error -= dy;

            if (error >= 0)
                continue;

            y += yStep;
            error += dx;
        }
    }
}