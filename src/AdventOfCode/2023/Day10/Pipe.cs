using System.Collections.Generic;
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
            var nextTile = ground.GetTileAt(nextPosition);
            var nextDirection = Tile.GetNextDirection(nextTile, direction);

            if (nextTile == Tile.StartingTile)
            {
                yield break;
            }

            position = nextPosition;
            direction = nextDirection;
        }
    }
}