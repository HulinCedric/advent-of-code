using System;
using System.Linq;

namespace AdventOfCode.Day04;

public static class BingoBoardFactory
{
    public static BingoBoard CreateWithRepresentation(string boardRepresentation)
        => new(
            boardRepresentation
                .Split("\n")
                .Select(
                    row => row
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray()));
}