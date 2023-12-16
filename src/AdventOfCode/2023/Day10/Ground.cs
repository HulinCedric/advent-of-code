using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2023.Day10;

public static class Ground
{
    public static char Tile(this Dictionary<Complex, char> ground, Complex position)
        => ground[position];

    public static Complex StartingPosition(this Dictionary<Complex, char> ground, char tile)
        => ground.Keys.First(position => ground[position] == tile);

    public static IEnumerable<IGrouping<double, Complex>> Lines(this Dictionary<Complex, char> ground)
        => ground.Keys.GroupBy(c => c.Imaginary).ToList();

    public static Complex SelectADirection(this Dictionary<Complex, char> ground, Complex position)
        => ground.AllPossibleDirection(position).First();

    public static IEnumerable<Complex> AllPossibleDirection(this Dictionary<Complex, char> ground, Complex position)
        => from direction in ground.Tile(position).Directions()
           let oppositeDirection = direction.OppositeDirection()
           let nextPosition = position + direction
           where ground.ContainsKey(nextPosition)
           let nexDirections = ground.Tile(nextPosition).Directions()
           where nexDirections.Contains(oppositeDirection)
           select direction;
}