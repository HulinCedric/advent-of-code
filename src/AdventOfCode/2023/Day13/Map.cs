using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day13;

public class Map : Dictionary<Position, char>
{
    private static readonly Position Start = new(0, 0);

    public Map(IEnumerable<KeyValuePair<Position, char>> toDictionary) : base(toDictionary)
    {
    }

    public IEnumerable<Position> MirrorPosition()
        => VerticalMirrorPosition(0)
            .Concat(HorizontalMirrorPosition(0));

    public IEnumerable<Position> MirrorWithSmudgePosition()
        => VerticalMirrorPosition(1)
            .Concat(HorizontalMirrorPosition(1));

    private IEnumerable<Position> VerticalMirrorPosition(int numberOfSmudge)
        => VerticalSlice()
            .Skip(1)
            .Where(mirror => IsMirror(mirror, Direction.Down, numberOfSmudge));

    private IEnumerable<Position> HorizontalMirrorPosition(int numberOfSmudge)
        => HorizontalSlice()
            .Skip(1)
            .Where(position => IsMirror(position, Direction.Right, numberOfSmudge));


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

    private IEnumerable<Position> VerticalSlice()
        => Positions(Start, Direction.Down);

    private IEnumerable<Position> HorizontalSlice()
        => Positions(Start, Direction.Right);

    private IEnumerable<Position> Positions(Position start, Direction direction)
    {
        for (var position = start; ContainsKey(position); position += direction)
        {
            yield return position;
        }
    }
}