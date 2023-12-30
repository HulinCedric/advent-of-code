using System;
using System.Globalization;

namespace AdventOfCode._2023.Day18;

public static class DigInstructionHexadecimalParser
{
    public static DigInstruction Parse(string instruction)
    {
        var hexadecimal = instruction.Split(' ')[2];

        return new DigInstruction(Direction(hexadecimal), Distance(hexadecimal));
    }

    private static int Distance(string hexadecimal)
        => int.Parse(hexadecimal[2..7], NumberStyles.HexNumber);

    private static Direction Direction(string hexadecimal)
        => hexadecimal[7] switch
        {
            '0' => Day18.Direction.Right,
            '1' => Day18.Direction.Up,
            '2' => Day18.Direction.Left,
            '3' => Day18.Direction.Down,
            _ => throw new ArgumentOutOfRangeException()
        };
}