using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day11;

public static class GalaxiesExtensions
{
    public static List<Galaxy> ExpandUniverse(List<Galaxy> originalGalaxies, long expandBy)
    {
        var galaxies = Copy(originalGalaxies);

        foreach (var galaxy in ToExpandInRow(galaxies))
        {
            galaxy.X += expandBy - 1;
        }

        foreach (var galaxy in ToExpandInColumn(galaxies))
        {
            galaxy.Y += expandBy - 1;
        }

        return galaxies;
    }

    private static List<Galaxy> Copy(List<Galaxy> originalGalaxies)
        => originalGalaxies.Select(g => new Galaxy(g.X, g.Y)).ToList();

    private static IEnumerable<Galaxy> ToExpandInColumn(List<Galaxy> galaxies)
        => Columns(galaxies)
            .Reverse()
            .Where(y => !IsColumnContainsGalaxies(galaxies, y))
            .SelectMany(y => galaxies.Where(galaxy => galaxy.Y > y));

    private static IEnumerable<Galaxy> ToExpandInRow(List<Galaxy> galaxies)
        => RowsIndex(galaxies)
            .Reverse()
            .Where(x => !IsRowContainsGalaxies(galaxies, x))
            .SelectMany(x => galaxies.Where(galaxy => galaxy.X > x));

    private static IEnumerable<int> Columns(List<Galaxy> galaxies)
        => Enumerable.Range((int)galaxies.Min(p => p.Y), (int)galaxies.Max(p => p.Y));

    private static IEnumerable<int> RowsIndex(List<Galaxy> galaxies)
        => Enumerable.Range((int)galaxies.Min(p => p.X), (int)galaxies.Max(p => p.X));

    private static bool IsRowContainsGalaxies(List<Galaxy> galaxies, int x)
        => galaxies.Any(galaxy => galaxy.X == x);

    private static bool IsColumnContainsGalaxies(List<Galaxy> galaxies, int y)
        => galaxies.Any(galaxy => galaxy.Y == y);

    public static IEnumerable<(Galaxy first, Galaxy second)> GalaxyPairs(List<Galaxy> galaxies)
        => from first in galaxies.Select((p, i) => (p, i))
           from second in galaxies.Skip(first.i)
           select (first.p, second);
}