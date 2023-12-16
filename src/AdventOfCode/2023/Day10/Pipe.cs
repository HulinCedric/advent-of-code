using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2023.Day10;

public static class Pipe
{
    public static IEnumerable<Complex> RunThrough(Dictionary<Complex, char> ground, char startingTile)
    {
        var position = ground.StartingPosition(startingTile);
        var direction = ground.SelectADirection(position);

        return RunThrough(ground, position, direction);
    }

    private static IEnumerable<Complex> RunThrough(
        Dictionary<Complex, char> ground,
        Complex position,
        Complex direction)
    {
        while (true)
        {
            yield return position;

            var nextPosition = position + direction;
            var nextTile = ground.Tile(nextPosition);
            var nextDirection = Tile.GetNextDirection(nextTile, direction);

            if (nextTile == Tile.StartingTile)
            {
                yield break;
            }

            position = nextPosition;
            direction = nextDirection;
        }
    }

    public static int CountEnclosedTiles(Dictionary<Complex, char> ground, HashSet<Complex> pipe)
        => ground
            .Lines()
            .Sum(line => CountEnclosedTilesInLine(line, ground, pipe));

    private static int CountEnclosedTilesInLine(
        IEnumerable<Complex> line,
        Dictionary<Complex, char> ground,
        HashSet<Complex> pipe)
    {
        var count = 0;
        var isEnclosedByPipe = false;
        foreach (var position in line)
        {
            if (pipe.Contains(position))
            {
                var tile = ground.Tile(position);
                isEnclosedByPipe = EvaluateEnclosure(tile, isEnclosedByPipe, ground, position);
                continue;
            }

            if (isEnclosedByPipe)
            {
                count++;
            }
        }

        return count;
    }

    private static bool EvaluateEnclosure(
        char tile,
        bool enclosedByPipe,
        Dictionary<Complex, char> ground,
        Complex position)
        => tile switch
        {
            _ when ground.AllPossibleDirection(position).Contains(Direction.North) => !enclosedByPipe,
            _ => enclosedByPipe
        };
}