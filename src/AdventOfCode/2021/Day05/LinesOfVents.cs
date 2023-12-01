using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day05;

public class LinesOfVents
{
    private readonly List<LineOfVent> lines;

    public LinesOfVents(List<LineOfVent> lines)
        => this.lines = lines;

    public int VerticalAndHorizontalAndDiagonalLineOverlapCount
        => GetOverlapCount(line => line.IsHorizontal || line.IsVertical || line.IsDiagonal45);

    public int VerticalAndHorizontalLineOverlapCount
        => GetOverlapCount(line => line.IsHorizontal || line.IsVertical);

    private int GetOverlapCount(Func<LineOfVent, bool> predicate)
        => lines
            .Where(predicate)
            .SelectMany(line => line.Coordinates)
            .GroupBy(coordinate => coordinate)
            .Count(group => group.Count() >= 2);
}