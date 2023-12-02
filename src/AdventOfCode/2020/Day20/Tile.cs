using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day20
{
    public record Tile
    {
        public Tile(int id, string representation)
        {
            Id = id;
            Content = representation.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToArray())
                .ToArray();
        }

        private IEnumerable<(string representation, TileBorder side)> Borders
        {
            get
            {
                yield return (TopBorder, TileBorder.Top);
                yield return (RightBorder, TileBorder.Right);
                yield return (BottomBorder, TileBorder.Bottom);
                yield return (LeftBorder, TileBorder.Left);
            }
        }

        public int Id { get; }

        private char[][] Content { get; init; }

        public string BottomBorder
            => new(
                Content
                    .Last());

        public string LeftBorder
            => string.Join(
                "",
                Content
                    .Select(s => s.First()));

        public string RightBorder
            => string.Join(
                "",
                Content
                    .Select(s => s.Last()));

        public string TopBorder
            => new(
                Content
                    .First());


        public virtual bool Equals(Tile? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && ToString() == other.ToString();
        }

        public override int GetHashCode()
            => HashCode.Combine(Id, ToString());

        public override string ToString()
            => $"Tile {Id}:\n" +
               string.Join(
                   "\n",
                   Content.Select(s => new string(s)));

        public static (bool areAdjacent, TileBorder? fromBorder, TileBorder? toBorder) AreAdjacent(
            Tile first,
            Tile second)
            => (from firstTileBorder in first.Borders
                from secondTileBorder in second.Borders
                where firstTileBorder.representation == secondTileBorder.representation
                select (true, firstTileBorder.side, secondTileBorder.side))
                .FirstOrDefault();

        public Tile VerticalFlip()
            => this with
            {
                Content =
                Content
                    .Reverse()
                    .ToArray()
            };

        public Tile HorizontalFlip()
            => this with
            {
                Content =
                Content
                    .Select(s => s.Reverse().ToArray())
                    .ToArray()
            };

        public Tile ClockwiseRotate()
        {
            char[][] ret = new char[Content.Length][];

            for (var i = 0; i < Content.Length; ++i)
            {
                ret[i] = new char[Content.Length];
                for (var j = 0; j < Content.Length; ++j)
                    ret[i][j] = Content[Content.Length - j - 1][i];
            }

            return this with
            {
                Content = ret
            };
        }

        public static (Tile first, Tile second) FindAdjacentOrientation(Tile first, Tile second)
            => (from f in first.AllOrientations()
                from s in second.AllOrientations()
                where AreAdjacent(f, s).areAdjacent
                select (f, s))
                .FirstOrDefault();

        public IEnumerable<Tile> AllOrientations()
        {
            var tile = this;
            for (var i = 1; i <= 8; i++)
            {
                yield return tile;

                if (i == 4)
                    tile = VerticalFlip();
                else if (i == 8)
                    yield break;

                tile = tile.ClockwiseRotate();
            }
        }
    }
}