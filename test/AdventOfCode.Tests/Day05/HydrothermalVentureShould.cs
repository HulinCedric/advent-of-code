using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day05
{
    public class HydrothermalVentureShould
    {
        [Theory]
        [InlineData(
            "0,9 -> 5,9\n8,0 -> 0,8\n9,4 -> 3,4\n2,2 -> 2,1\n7,0 -> 7,4\n6,4 -> 2,0\n0,9 -> 2,9\n3,4 -> 1,4\n0,0 -> 8,8\n5,5 -> 8,2",
            5)]
        // [InputFileData("Day05/input.txt", ?)]
        public void At_how_many_points_do_at_least_two_lines_overlap(
            string nearbyLinesOfVentsRepresentation,
            int expectedOverlap)
        {
            // Given
            var lineOfVents =
                LineOfVentsFactory.CreateForRepresentation(nearbyLinesOfVentsRepresentation);

            // When
            var actualOverlapCount = lineOfVents.OverlapCount;

            // Then
            actualOverlapCount.Should().Be(expectedOverlap);
        }
    }

    public record LineOfVent(Coordinate C1, Coordinate C2)
    {
    }

    public record Coordinate(int X, int Y)
    {
    }

    public abstract class LineOfVentsFactory
    {
        public static LineOfVents CreateForRepresentation(string nearbyLinesOfVentsRepresentation)
            => new(
                nearbyLinesOfVentsRepresentation.Split("\n")
                    .Select(
                        lineRepresentation =>
                        {
                            var coordinates = lineRepresentation.Split(" -> ")
                                .Select(
                                    coordinateRepresentation =>
                                    {
                                        var coordinatePoint = coordinateRepresentation.Split(",")
                                            .Select(int.Parse);
                                        return new Coordinate(coordinatePoint.First(), coordinatePoint.Last());
                                    });
                            return new LineOfVent(coordinates.First(), coordinates.Last());
                        })
                    .ToList());
    }

    public class LineOfVents
    {
        private readonly List<LineOfVent> lines;

        public LineOfVents(List<LineOfVent> lines)
            => this.lines = lines;

        public int OverlapCount
            => 0;
    }
}