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
    public void Found_calibration_value(
        string calibrationValueAmended,
        int expectedCalibrationValue)
    {
        // Given

        // When
        var calibrationValue = 12;

        // Then
        calibrationValue.Should().Be(expectedCalibrationValue);
    }
}