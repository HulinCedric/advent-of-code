using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day08;

public class StuffShould
{
    [Theory]
    [InputFileData("Day08/sample.txt", 26)]
    [InputFileData("Day08/input.txt", 344)]
    public void In_the_output_values_how_many_times_do_digits_1_4_7_or_8_appear(
        string description,
        int expected)
    {
        // Given
        var segmentCounts = new List<int>
        {
            2, // 1
            3, // 7
            4, // 4
            7, // 8
        };

        var digitsOutputs = description.Split("\n")
            .Select(line => line.Split(" | "))
            .Select(signalParts => signalParts[1])
            .SelectMany(outputDescription => outputDescription.Split(" "))
            .ToArray();

        // When
        var digitCount = digitsOutputs
            .Select(digitOutput => digitOutput.Length)
            .Count(segmentCount => segmentCounts.Contains(segmentCount));

        // Then
        digitCount.Should().Be(expected);
    }

    [Theory]
    [InlineData("gc")]
    [InlineData("ed")]
    [InlineData("cgb")]
    [InlineData("gcbe")]
    [InlineData("fdgacbe")]
    public void Signal_length_correspond_to_digit_by_segment_count(
        string digitSignalOutput)
    {
        var segmentCounts = new List<int>
        {
            2, // 1
            3, // 7
            4, // 4
            7, // 8
        };

        // When
        var isDigit = false;

        var segmentCount = digitSignalOutput.Length;
        if (segmentCounts.Contains(segmentCount))
        {
            isDigit = true;
        }

        // Then
        isDigit.Should().BeTrue();
    }
}