using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day14.Map;
using static AdventOfCode._2023.Day14.SupportBeam;

namespace AdventOfCode._2023.Day14;

public class SupportBeamShould
{
    [Theory]
    [InputFileData("2023/Day14/sample_tilted.txt", 136)]
    public void Calculate_total_load(string map, int totalLoad)
        => TotalLoad(Parse(map))
            .Should()
            .Be(totalLoad);
}