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
        => ground.Keys.Count(position => position.IsEnclosedByPipe(ground, pipe));

    // Inspired by encse solution
    private static bool IsEnclosedByPipe(this Complex position, Dictionary<Complex, char> ground, HashSet<Complex> pipe)
    {
        if (pipe.Contains(position))
        {
            return false;
        }

        var enclosedByPipe = false;
        position += Direction.East;
        while (ground.ContainsKey(position))
        {
            if (pipe.Contains(position) &&
                ground.Tile(position).Directions().Contains(Direction.North))
            {
                enclosedByPipe = !enclosedByPipe;
            }

            position += Direction.East;
        }

        return enclosedByPipe;
    }
}