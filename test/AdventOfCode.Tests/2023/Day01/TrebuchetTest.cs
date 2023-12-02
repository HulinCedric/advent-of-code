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
        var sumOfCalibrationValues = calibrationValuesAmended.Select(Trebuchet.FindCalibrationValue).Sum();

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
        var sumOfCalibrationValues =
            calibrationValuesAmended.Select(Trebuchet.FindCalibrationValueWithSpelledOutDigit).Sum();

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
        var calibrationValue = Trebuchet.FindCalibrationValue(calibrationValueAmended);

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
        var calibrationValue = Trebuchet.FindCalibrationValueWithSpelledOutDigit(calibrationValueAmended);

        // Then
        calibrationValue.Should().Be(expectedCalibrationValue);
    }
}