using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day17.CrucibleFactory;
using static AdventOfCode._2023.Day17.MapParser;

namespace AdventOfCode._2023.Day17;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day17/sample1.txt", 102)]
    [InputFileData("2023/Day17/input.txt", 724)]
    public void Least_heat_loss_with_normal_crucible(string input, int result)
        => ParseMap(input)
            .LeastHeatLoss(NormalCrucible())
            .Should()
            .Be(result);

    [Theory]
    [InputFileData("2023/Day17/sample1.txt", 94)]
    [InputFileData("2023/Day17/sample2.txt", 71)]
    [InputFileData("2023/Day17/input.txt", 877)]
    public void Least_heat_loss_with_ultra_crucible(string input, int result)
        => ParseMap(input)
            .LeastHeatLoss(UltraCrucible())
            .Should()
            .Be(result);
}