using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day11;

public class UniverseTest
{
    [Theory]
    [InputFileData("2023/Day11/sample.txt", 2, 374L)]
    [InputFileData("2023/Day11/input.txt", 2, 9_647_174L)]
    [InputFileData("2023/Day11/sample.txt", 1_000_000, 82_000_210L)]
    [InputFileData("2023/Day11/input.txt", 1_000_000, 377_318_892_554L)]
    public void Should_Sum_Galaxies_Distances_In_Expanded_Universe(
        string universeImage,
        int expansionFactor,
        long distance)
    {
        var universe = UniverseExtension.Universe(universeImage);
        var galaxies = UniverseExtension.Galaxies(universe);

        var expandedGalaxies = GalaxiesExtensions.ExpandUniverse(galaxies, expansionFactor);

        GalaxiesExtensions.GalaxyPairs(expandedGalaxies)
            .Sum(pair => pair.first.Distance(pair.second))
            .Should()
            .Be(distance);
    }
}