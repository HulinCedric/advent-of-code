using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day05;

public class HydrothermalVentureShould
{
    [Theory]
    [InlineData(
        "0,9 -> 5,9\n8,0 -> 0,8\n9,4 -> 3,4\n2,2 -> 2,1\n7,0 -> 7,4\n6,4 -> 2,0\n0,9 -> 2,9\n3,4 -> 1,4\n0,0 -> 8,8\n5,5 -> 8,2",
        5)]
    [InputFileData("Day05/input.txt", 4745)]
    public void At_how_many_points_do_at_least_two_lines_overlap_horizontally_vertically(
        string nearbyLinesOfVentsRepresentation,
        int expectedOverlap)
    {
        // Given
        var lineOfVents =
            LineOfVentsFactory.CreateForRepresentation(nearbyLinesOfVentsRepresentation);

        // When
        var actualOverlapCount = lineOfVents.VerticalAndHorizontalLineOverlapCount;

        // Then
        actualOverlapCount.Should().Be(expectedOverlap);
    }

    [Theory]
    [InlineData(
        "0,9 -> 5,9\n8,0 -> 0,8\n9,4 -> 3,4\n2,2 -> 2,1\n7,0 -> 7,4\n6,4 -> 2,0\n0,9 -> 2,9\n3,4 -> 1,4\n0,0 -> 8,8\n5,5 -> 8,2",
        12)]
    [InputFileData("Day05/input.txt", 18442)]
    public void At_how_many_points_do_at_least_two_lines_overlap_horizontally_vertically_and_on_diagonals(
        string nearbyLinesOfVentsRepresentation,
        int expectedOverlap)
    {
        // Given
        var lineOfVents =
            LineOfVentsFactory.CreateForRepresentation(nearbyLinesOfVentsRepresentation);

        // When
        var actualOverlapCount = lineOfVents.VerticalAndHorizontalAndDiagonalLineOverlapCount;

        // Then
        actualOverlapCount.Should().Be(expectedOverlap);
    }
}