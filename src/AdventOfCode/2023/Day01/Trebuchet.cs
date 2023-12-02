using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day01;

public static partial class Trebuchet
{
    private static readonly Dictionary<string, string> SpelledOutDigitTranslation = new()
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" }
    };

    public static int FindCalibrationValue(string calibrationValueAmended)
    {
        var firstDigit = calibrationValueAmended.First(char.IsDigit);
        var lastDigit = calibrationValueAmended.Last(char.IsDigit);

        return int.Parse(string.Concat(firstDigit, lastDigit));
    }

    public static int FindCalibrationValueWithSpelledOutDigit(string calibrationValueAmended)
    {
        var firstDigit = "";

        var accumulator = "";
        for (var i = 0; i < calibrationValueAmended.Length; i++)
        {
            accumulator = accumulator + calibrationValueAmended[i];

            accumulator = ReplaceSpelledOutDigit(accumulator);

            if (accumulator.Any(char.IsDigit))
            {
                firstDigit = accumulator.First(char.IsDigit).ToString();
                break;
            }
        }


        // Reverse calibrationValueAmended and use reversed spelledOutDigitTranslation
        var lastDigit = "";

        accumulator = "";

        for (var i = calibrationValueAmended.Length - 1; i >= 0; i--)
        {
            accumulator = calibrationValueAmended[i] + accumulator;

            accumulator = ReplaceSpelledOutDigit(accumulator);

            if (accumulator.Any(char.IsDigit))
            {
                lastDigit = accumulator.Last(char.IsDigit).ToString();
                break;
            }
        }

        return int.Parse(string.Concat(firstDigit, lastDigit));
    }

    private static string ReplaceSpelledOutDigit(string calibrationValueAmended)
        => SpelledOutDigitRegex()
            .Replace(
                calibrationValueAmended,
                match => SpelledOutDigitTranslation[match.Value]);

    [GeneratedRegex("(one|two|three|four|five|six|seven|eight|nine)")]
    private static partial Regex SpelledOutDigitRegex();
}