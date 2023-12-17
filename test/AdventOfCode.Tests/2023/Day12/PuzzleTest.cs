using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day12;

public class PuzzleTest
{
    [Theory]
    [InputFileData("2023/Day12/sample.txt", 1, 21)]
    [InputFileData("2023/Day12/input.txt", 1, 6981L)]
    [InputFileData("2023/Day12/sample.txt", 5, 525152)]
    [InputFileData("2023/Day12/input.txt", 5, 4546215031609L)]
    public void Count_all_possible_arrangements(
        string springsConditionRecords,
        int repeat,
        long arrangements)
        => Puzzle.Solve(springsConditionRecords, repeat)
            .Should()
            .Be(arrangements);
}

public static class Puzzle
{
    public static long Solve(string input, int repeat)
        => (from line in input.Split("\n")
            let record = SpringConditionRecordExtensions.Parse(line)
            let unfolded = SpringConditionRecordExtensions.Unfold(record, repeat)
            select unfolded.Arrangements()).Sum();
}