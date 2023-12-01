using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day01;

public class TrebuchetTest
{
    [Theory]
    [InlineData("1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet", 142)]
    [InputFileData("2023/Day01/input.txt", 54697)]
    public void What_is_the_sum_of_all_of_the_calibration_values(
        string calibrationDocument,
        int expectedSumOfCalibrationValues)
    {
        // Given
        var calibrationValuesAmended = calibrationDocument.Split("\n");

        // When
        var sumOfCalibrationValues = calibrationValuesAmended.Select(FindCalibrationValue).Sum();

        // Then
        sumOfCalibrationValues.Should().Be(expectedSumOfCalibrationValues);
    }

    [Theory]
    [InlineData(
        "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen",
        281)]
    [InputFileData("2023/Day01/input.txt", 54885)]
    public void What_is_the_sum_of_all_of_the_calibration_values_with_spelled_out_digit(
        string calibrationDocument,
        int expectedSumOfCalibrationValues)
    {
        // Given
        var calibrationValuesAmended = calibrationDocument.Split("\n");

        // When
        var sumOfCalibrationValues = calibrationValuesAmended.Select(FindCalibrationValueWithSpelledOutDigit).Sum();

        // Then
        sumOfCalibrationValues.Should().Be(expectedSumOfCalibrationValues);
    }

    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("npqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("ntreb7uchet", 77)]
    public void Find_calibration_value_with_digit(
        string calibrationValueAmended,
        int expectedCalibrationValue)
    {
        // When
        var calibrationValue = FindCalibrationValue(calibrationValueAmended);

        // Then
        calibrationValue.Should().Be(expectedCalibrationValue);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void Find_calibration_value_with_spelled_out_digit(
        string calibrationValueAmended,
        int expectedCalibrationValue)
    {
        // When
        var calibrationValue = FindCalibrationValueWithSpelledOutDigit(calibrationValueAmended);

        // Then
        calibrationValue.Should().Be(expectedCalibrationValue);
    }

    [Theory]
    [InlineData("two1nine", "219")]
    [InlineData("eightwothree", "8wo3")]
    [InlineData("abcone2threexyz", "abc123xyz")]
    [InlineData("xtwone3four", "x2ne34")]
    [InlineData("4nineeightseven2", "49872")]
    [InlineData("zoneight234", "z1ight234")]
    [InlineData("7pqrstsixteen", "7pqrst6teen")]
    public void Replace_spelled_out_digit_in_calibration_value_amended(
        string calibrationValueAmended,
        string expectedCalibrationValueAmended)
    {
        // When
        var newCalibrationValueAmended = ReplaceSpelledOutDigit(calibrationValueAmended);

        // Then
        newCalibrationValueAmended.Should().Be(expectedCalibrationValueAmended);
    }

    private static int FindCalibrationValueWithSpelledOutDigit(string calibrationValueAmended)
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
    {
        var spelledOutDigitTranslation = new Dictionary<string, string>
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

        const string pattern = "(one|two|three|four|five|six|seven|eight|nine)";

        return Regex.Replace(
            calibrationValueAmended,
            pattern,
            match => spelledOutDigitTranslation[match.Value]);
    }

    private static int FindCalibrationValue(string calibrationValueAmended)
    {
        var firstDigit = calibrationValueAmended.First(char.IsDigit);
        var lastDigit = calibrationValueAmended.Last(char.IsDigit);

        return int.Parse(string.Concat(firstDigit, lastDigit));
    }
}