using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day13;

public class Map : Dictionary<Position, char>
{
    private static readonly Position Start = new(0, 0);

    public Map(IEnumerable<KeyValuePair<Position, char>> toDictionary) : base(toDictionary)
    {
    }

    public Position MirrorPosition()
        => MirrorPositionWith(numberOfSmudge: 0);

    public Position MirrorWithSmudgePosition()
        => MirrorPositionWith(numberOfSmudge: 1);

    private Position MirrorPositionWith(int numberOfSmudge)
        => ArraySegment<Position>.Empty
            .Concat(MirrorPositionIn(Direction.Down, numberOfSmudge))
            .Concat(MirrorPositionIn(Direction.Right, numberOfSmudge))
            .First();

    private IEnumerable<Position> MirrorPositionIn(Direction direction, int numberOfSmudge)
        => SliceIn(direction)
            .Skip(1)
            .Where(position => IsMirror(position, direction, numberOfSmudge));

    private IEnumerable<Position> SliceIn(Direction direction)
        => Positions(Start, direction);

    private bool IsMirror(Position position, Direction direction, int numberOfSmudge)
        => (
               from mirror in Positions(position, direction.Orthogonal())
               let pattern = Positions(mirror, direction)
               let reflectedPattern = Positions(mirror - direction, direction.Reverse())
               select CountAsymmetry(pattern, reflectedPattern)
           ).Sum() ==
           numberOfSmudge;

    private int CountAsymmetry(IEnumerable<Position> pattern, IEnumerable<Position> reflectedPattern)
        => pattern.Zip(reflectedPattern).Count(positions => this[positions.First] != this[positions.Second]);

    private IEnumerable<Position> Positions(Position start, Direction direction)
    {
        for (var position = start; ContainsKey(position); position += direction)
        {
            yield return position;
        }
    }
}