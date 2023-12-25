using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day13;

public class Map : Dictionary<Position, char>
{
    public Map(IEnumerable<KeyValuePair<Position, char>> toDictionary) : base(toDictionary)
    {
    }

    public IEnumerable<KeyValuePair<Position, char>> GetVerticalSlice()
        => Positions(new Position(0, 0), Direction.Down)
            .Select(position => new KeyValuePair<Position, char>(position, this[position]));

    public IEnumerable<KeyValuePair<Position, char>> GetHorizontalSlice()
        => Positions(new Position(0, 0), Direction.Right)
            .Select(position => new KeyValuePair<Position, char>(position, this[position]));

    private IEnumerable<Position> Positions(Position start, Direction direction)
    {
        for (var position = start; ContainsKey(position); position += direction)
        {
            yield return position;
        }
    }

    public IEnumerable<Position> GetMirrorPosition()
        => GetVerticalMirrorPosition()
            .Concat(GetHorizontalMirrorPosition())
            .Select(mirror => mirror.Key);

    public IEnumerable<KeyValuePair<Position, char>> GetVerticalMirrorPosition()
        => GetVerticalSlice()
            .Skip(1)
            .Where(mirror => IsMirror(mirror.Key, Direction.Down))
            .Select(mirror => mirror);

    public IEnumerable<KeyValuePair<Position, char>> GetHorizontalMirrorPosition()
        => GetHorizontalSlice()
            .Skip(1)
            .Where(position => IsMirror(position.Key, Direction.Right))
            .Select(mirror => mirror);

    private bool IsMirror(Position position, Direction direction)
        => (
               from mirror in Positions(position, direction.Orthogonal())
               let pattern = Positions(mirror, direction)
               let reflectedPattern = Positions(mirror - direction, direction.Reverse())
               select AreSymmetric(pattern, reflectedPattern)
           ).All(areSymmetric => areSymmetric);

    private bool AreSymmetric(IEnumerable<Position> pattern, IEnumerable<Position> reflectedPattern)
        => pattern.Zip(reflectedPattern).All(positions => this[positions.First] == this[positions.Second]);
}