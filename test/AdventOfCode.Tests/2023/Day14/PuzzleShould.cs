using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day14.MapParser;

namespace AdventOfCode._2023.Day14;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day14/sample.txt", 136)]
    [InputFileData("2023/Day14/input.txt", 109_755)]
    public void Calculate_total_load_of_tilted_map(string map, int measure)
        => SupportBeam.TotalLoad(Parse(map).Tilt()).Should().Be(measure);
}