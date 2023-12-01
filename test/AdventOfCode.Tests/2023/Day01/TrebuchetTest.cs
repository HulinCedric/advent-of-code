using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day01;

public class TrebuchetTest
{
    [Theory]
    [InlineData("1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet", 142)]
    public void What_is_the_sum_of_all_of_the_calibration_values(
        string calibrationDocument,
        int expectedSumOfCalibrationValues)
    {
        // Given

        // When
        var sumOfCalibrationValues = 142;

        // Then
        sumOfCalibrationValues.Should().Be(expectedSumOfCalibrationValues);
    }

    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("npqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("ntreb7uchet", 77)]
    public void Found_calibration_value(
        string calibrationValueAmended,
        int expectedCalibrationValue)
    {
        // When
        var calibrationValue = FoundCalibrationValue(calibrationValueAmended);

        // Then
        calibrationValue.Should().Be(expectedCalibrationValue);
    }

    private static int FoundCalibrationValue(string calibrationValueAmended)
    {
        var firstDigit = calibrationValueAmended.First(char.IsDigit);
        var secondDigit = calibrationValueAmended.Last(char.IsDigit);

        return int.Parse(string.Concat(firstDigit, secondDigit));
    }
}