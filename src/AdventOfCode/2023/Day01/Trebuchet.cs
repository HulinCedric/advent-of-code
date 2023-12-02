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

    public static int ParseCalibrationValue(string calibrationValueAmended)
        => ComputeCalibrationValue(
            FirstDigit(calibrationValueAmended),
            LastDigit(calibrationValueAmended));

    public static int ParseCalibrationValueWithSpelledOutDigit(string calibrationValueAmended)
        => ComputeCalibrationValue(
            FirstDigit(TranslateSpelledOutDigitFromTheBeginning(calibrationValueAmended)),
            LastDigit(TranslateSpelledOutDigitFromTheEnd(calibrationValueAmended)));

    private static string FirstDigit(string calibrationValueAmended)
        => calibrationValueAmended.First(char.IsDigit).ToString();

    private static string LastDigit(string calibrationValueAmended)
        => calibrationValueAmended.Last(char.IsDigit).ToString();

    private static string TranslateSpelledOutDigitFromTheBeginning(string calibrationValueAmended)
        => calibrationValueAmended
            .Aggregate(
                "",
                (accumulator, current) => ReplaceSpelledOutDigit(accumulator + current, SpelledOutDigitTranslation));

    private static string TranslateSpelledOutDigitFromTheEnd(string calibrationValueAmended)
        => calibrationValueAmended
            .Reverse()
            .Aggregate(
                "",
                (accumulator, current) => ReplaceSpelledOutDigit(current + accumulator, SpelledOutDigitTranslation));

    private static string ReplaceSpelledOutDigit(
        string calibrationValueAmended,
        Dictionary<string, string> spelledOutDigitTranslation)
        => SpelledOutDigitRegex()
            .Replace(
                calibrationValueAmended,
                match => spelledOutDigitTranslation[match.Value]);

    [GeneratedRegex("(one|two|three|four|five|six|seven|eight|nine)")]
    private static partial Regex SpelledOutDigitRegex();

    private static int ComputeCalibrationValue(string firstDigit, string lastDigit)
        => int.Parse(string.Concat(firstDigit, lastDigit));
}