using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day13;

public class Map : Dictionary<Position, char>
{
    public Map(IEnumerable<KeyValuePair<Position, char>> toDictionary) : base(toDictionary)
    {
    }

    public Map GetVerticalSlice()
        => new(
            Positions(this, new Position(0, 0), Direction.Down)
                .Select(position => new KeyValuePair<Position, char>(position, this[position])));

    public Map GetHorizontalSlice()
        => new(
            Positions(this, new Position(0, 0), Direction.Right)
                .Select(position => new KeyValuePair<Position, char>(position, this[position])));


    private static IEnumerable<Position> Positions(Map map, Position start, Direction direction)
    {
        for (var position = start; map.ContainsKey(position); position += direction)
        {
            yield return position;
        }
    }
}