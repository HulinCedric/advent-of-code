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
    public void Count_all_possible_springs_arrangements(
        string springsConditionRecords,
        int repeat,
        long expected)
    {
        var springsArrangements = springsConditionRecords.Split("\n")
            .Select(SpringConditionRecordExtensions.SpringConditionRecord)
            .Select(record => record.Unfold(repeat))
            .Select(unfoldedRecord => unfoldedRecord.Arrangements());

        springsArrangements.Sum()
            .Should()
            .Be(expected);
    }
}