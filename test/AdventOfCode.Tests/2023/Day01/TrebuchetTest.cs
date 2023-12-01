using System.Collections.Generic;
using System.Linq;
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
    [InlineData("one", "1")]
    [InlineData("two", "2")]
    [InlineData("three", "3")]
    [InlineData("four", "4")]
    [InlineData("five", "5")]
    [InlineData("six", "6")]
    [InlineData("seven", "7")]
    [InlineData("eight", "8")]
    [InlineData("nine", "9")]
    [InlineData("unknown", "unknown")]
    public void Translate_spelled_out_digit(
        string calibrationValueAmended,
        string expectedCalibrationValue)
    {
        // When
        var digit = TranslateSpelledOutDigitToDigit(calibrationValueAmended);

        // Then
        digit.Should().Be(expectedCalibrationValue);
    }

    private static string TranslateSpelledOutDigitToDigit(string calibrationValueAmended)
    {
        var spelledOutDigits = new Dictionary<string, string>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
        };
        
        return spelledOutDigits.GetValueOrDefault(calibrationValueAmended, calibrationValueAmended);
    }

    private static int FindCalibrationValue(string calibrationValueAmended)
    {
        var firstDigit = calibrationValueAmended.First(char.IsDigit);
        var lastDigit = calibrationValueAmended.Last(char.IsDigit);

        return int.Parse(string.Concat(firstDigit, lastDigit));
    }
}