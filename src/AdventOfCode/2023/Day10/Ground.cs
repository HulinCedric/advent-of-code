using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2023.Day10;

public static class Animal
{
    public static Complex SelectADirection(this Dictionary<Complex, char> ground, Complex position)
        => AllPossibleDirection(ground, position).First();

    private static IEnumerable<Complex> AllPossibleDirection(Dictionary<Complex, char> ground, Complex position)
        => from direction in ground.GetTileAt(position).GetAllDirections()
           let oppositeDirection = direction.OppositeDirection()
           let nextPosition = position + direction
           let nexDirections = ground.GetTileAt(nextPosition).GetAllDirections()
           where nexDirections.Contains(oppositeDirection)
           select direction;
}

public static class Ground
{
    public static char GetTileAt(this Dictionary<Complex, char> ground, Complex position)
        => ground[position];

    public static Complex StartingPosition(this Dictionary<Complex, char> ground, char tile)
        => ground.Keys.First(position => ground[position] == tile);
}