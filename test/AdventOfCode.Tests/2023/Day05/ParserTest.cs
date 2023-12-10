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
        var almanac = AlmanacParser.Parse(almanacInformation);

        var lowestLocation = almanac.GetLowestLocation();

        lowestLocation.Should().Be(expectedLowestLocation);
    }

    [Theory]
    [InputFileData("2023/Day05/sample.txt", 46)]
    [InputFileData("2023/Day05/input.txt", 9622622)]
    public void part_two(string almanacInformation, long expectedLowestLocation)
    {
        var almanac = AlmanacParser.ParseWithRange(almanacInformation);

        var lowestLocation = almanac.GetLowestLocation();

        lowestLocation.Should().Be(expectedLowestLocation);
    }
}