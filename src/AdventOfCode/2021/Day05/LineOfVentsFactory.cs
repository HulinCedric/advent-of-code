using System.Linq;

namespace AdventOfCode._2021.Day05;

public abstract class LineOfVentsFactory
{
    public static LinesOfVents CreateForRepresentation(string nearbyLinesOfVentsRepresentation)
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