using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day03;

public static class GondolaEngine
{
    public static int CalculatePartNumbersSum(string[] schematic)
    {
        var partNumbers = ParseInSchematic<Number>(schematic);
        var symbols = ParseInSchematic<Symbol>(schematic);

        return (from number in partNumbers
                from symbol in symbols
                where number.IsAdjacent(symbol)
                select number.Value).Sum();
    }

    public static int CalculateGearRatioSum(string[] schematic)
    {
        var gears = ParseInSchematic<Gear>(schematic);
        var numbers = ParseInSchematic<Number>(schematic);

        return gears
            .Select(gear => numbers.Where(number => number.IsAdjacent(gear)).ToArray())
            .Where(gearPartNumbers => gearPartNumbers.Length == 2)
            .Sum(gearsPartNumbers => gearsPartNumbers[0].Value * gearsPartNumbers[1].Value);
    }

    public static List<TPart> ParseInSchematic<TPart>(string[] schematic) where TPart : Part
    {
        var regexMethod = typeof(TPart).GetMethod("Regex", BindingFlags.Static | BindingFlags.NonPublic);
        var regex = (Regex)regexMethod!.Invoke(null, null)!;
        return ParseInMap<TPart>(schematic, regex);
    }

    private static List<TPart> ParseInMap<TPart>(string[] schematic, Regex regex) where TPart : Part
    {
        var parts = new List<TPart>();

        for (var rowIndex = 0; rowIndex < schematic.Length; rowIndex++)
        {
            foreach (Match found in regex.Matches(schematic[rowIndex]))
            {
                parts.Add(PartFactory.Create<TPart>(found.Value, rowIndex, found.Index));
            }
        }

        return parts;
    }
}