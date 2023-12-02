using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day20
{
    public static class CameraArray
    {
        public static IEnumerable<int> FindCornerIds(IEnumerable<Tile> tiles)
        {
            var allOrientedTiles = tiles
                .SelectMany(x => x.AllOrientations())
                .ToArray();

            var allOrientedCornerTiles = allOrientedTiles
                .Where(
                    tile => !allOrientedTiles.Any(
                                otherTile => otherTile.RightBorder == tile.LeftBorder &&
                                             otherTile.Id != tile.Id) &&
                            !allOrientedTiles.Any(
                                otherTile => otherTile.BottomBorder == tile.TopBorder &&
                                             otherTile.Id != tile.Id))
                .ToArray();

            var ids = allOrientedCornerTiles
                .Select(x => x.Id)
                .Distinct()
                .ToArray();

            return ids;
        }
    }
}