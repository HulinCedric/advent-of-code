using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day05;

public class ParserTest
{
    [Theory]
    [InputFileData("2023/Day05/sample.txt", 35)]
    [InputFileData("2023/Day05/input.txt", 510109797)]
    public void Should_Get_Lowest_Location(string almanacInformation, long expectedLowestLocation)
    {
        var gardener = AlmanacParser.Parse(almanacInformation);

        var lowestLocation = gardener.GetLowestLocation();

        lowestLocation.Should().Be(expectedLowestLocation);
    }

    [Theory]
    [InputFileData("2023/Day05/sample.txt", 46)]
    [InputFileData("2023/Day05/input.txt", 46)]
    public void part_two(string almanacInformation, long expectedLowestLocation)
    {
        var gardener = AlmanacParser.Parse_Two(almanacInformation);

        var lowestLocation = gardener.GetLowestLocation();

        lowestLocation.Should().Be(expectedLowestLocation);
    }
}