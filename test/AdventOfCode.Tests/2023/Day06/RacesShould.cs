using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day06;

public class RacesShould
{
    [Theory]
    [InputFileData("2023/Day06/sample.txt", 288)]
    [InputFileData("2023/Day06/input.txt", 281_600)]
    public void Calculate_ways_to_win(
        string racesInformation,
        int waysToBeatTheRecord)
        => RacesParser.RacesParse(racesInformation)
            .Select(race => race.CalculateWaysToWin())
            .Multiply()
            .Should()
            .Be(waysToBeatTheRecord);

    [Theory]
    [InputFileData("2023/Day06/sample.txt", 71_503)]
    [InputFileData("2023/Day06/input.txt", 33_875_953)]
    public void Calculate_ways_to_win_with_fix_kerning(
        string racesInformation,
        int waysToBeatTheRecord)
        => RacesParser.RacesParse(racesInformation.FixKerning())
            .Select(race => race.CalculateWaysToWin())
            .Multiply()
            .Should()
            .Be(waysToBeatTheRecord);
}