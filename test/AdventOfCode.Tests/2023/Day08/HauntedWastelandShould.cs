using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day08;

public class HauntedWastelandShould
{
    [Theory]
    [InputFileData("2023/Day08/sample1.txt", "AAA", "ZZZ", 2)]
    [InputFileData("2023/Day08/sample2.txt", "AAA", "ZZZ", 6)]
    [InputFileData("2023/Day08/input.txt", "AAA", "ZZZ", 20221)]
    [InputFileData("2023/Day08/sample3.txt", "A", "Z", 6)]
    [InputFileData("2023/Day08/input.txt", "A", "Z", 14616363770447)]
    public void Reach_ending_location_in_expected_steps(
        string mapDocument,
        string startingLocation,
        string endingLocation,
        long steps)
        => mapDocument.Steps(startingLocation, endingLocation).Should().Be(steps);
}