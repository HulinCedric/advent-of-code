using System;

namespace AdventOfCode._2023.Day18;

public static class DigInstructionDigitParser
{
    public static DigInstruction Parse(string instruction)
    {
        var parts = instruction.Split();

        return new DigInstruction(Direction(parts), Distance(parts));
    }

    private static long Distance(string[] parts)
        => long.Parse(parts[1]);

    private static Direction Direction(string[] parts)
        => parts[0][0] switch
        {
            'R' => Day18.Direction.Right,
            'U' => Day18.Direction.Up,
            'L' => Day18.Direction.Left,
            'D' => Day18.Direction.Down,
            _ => throw new Exception()
        };
}