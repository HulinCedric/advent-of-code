using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode._2023.Day18;

public class DigPlan(IEnumerable<DigInstruction> digInstructions)
{
    public Lagoon Dig()
        => new(Dig(digInstructions.Select(instruction => instruction.Execute())));

    private static IEnumerable<Coordinate> Dig(IEnumerable<DigStep> steps)
    {
        var trenches = steps.Aggregate(
            ImmutableList.Create(new Coordinate(0, 0)),
            (coordinates, step) => coordinates.Add(coordinates.Last() + step));

        return trenches.Add(trenches.First()).ToList();
    }
}