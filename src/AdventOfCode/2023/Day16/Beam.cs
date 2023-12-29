using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2023.Day16.Tiles;

namespace AdventOfCode._2023.Day16;

public record Beam(Position Position, Direction Direction)
{
    public Beam[] Bounce(Tile tile)
        => tile.Reflect(Direction)
            .Select(reflectionDirection => new Beam(Position.GoTo(reflectionDirection), reflectionDirection))
            .ToArray();

    public static IEnumerable<Beam> StartingBeams(Contraption contraption)
    {
        var topLeft = contraption.TopLeft();
        var bottomRight = contraption.BottomRight();
        return
        [
            ..from p in contraption.Positions() where p.Column == topLeft.Column select new Beam(p, Direction.Right),
            ..from p in contraption.Positions() where p.Column == bottomRight.Column select new Beam(p, Direction.Left),
            ..from p in contraption.Positions() where p.Row == bottomRight.Row select new Beam(p, Direction.Up),
            ..from p in contraption.Positions() where p.Row == topLeft.Row select new Beam(p, Direction.Down)
        ];
    }
}