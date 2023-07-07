using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day08;

public class SevenSegmentDecoderShould
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
            7 // 8
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
    [InputFileData("Day08/sample.txt", 61229)]
    [InputFileData("Day08/input.txt", 1048410)]
    public void What_do_you_get_if_you_add_up_all_of_the_output_values(
        string description,
        int expected)
    {
        // Given
        var segmentCounts = new List<int>
        {
            2, // 1
            3, // 7
            4, // 4
            7 // 8
        };

        var input = description.Split("\n");

        // When
        var outputSum = input.Sum(i => SevenSegmentDecoder.Decode(i));

        // Then
        outputSum.Should().Be(expected);
    }

    [Theory]
    [InlineData("gc")]
    [InlineData("ed")]
    [InlineData("cgb")]
    [InlineData("gcbe")]
    [InlineData("fdgacbe")]
    public void Validate_digit_by_segment_count(
        string digitSignalOutput)
    {
        var segmentCounts = new List<int>
        {
            2, // 1
            3, // 7
            4, // 4
            7 // 8
        };

        // When
        var isDigit = false;

        var segmentCount = digitSignalOutput.Length;
        if (segmentCounts.Contains(segmentCount))
            isDigit = true;

        // Then
        isDigit.Should().BeTrue();
    }

    [Theory]
    [InlineData("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", 8394)]
    [InlineData("edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", 9781)]
    [InlineData("fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", 1197)]
    public void Decode_seven_segment_output(string input, int fourDigitOutput)
        => SevenSegmentDecoder.Decode(input).Should().Be(fourDigitOutput);

    [Theory]
    [InlineData("agebfd", 0)]
    [InlineData("be", 1)]
    [InlineData("fabcd", 2)]
    [InlineData("fecdb", 3)]
    [InlineData("cgeb", 4)]
    [InlineData("fdcge", 5)]
    [InlineData("fgaecd", 6)]
    [InlineData("edb", 7)]
    [InlineData("cfbegad", 8)]
    [InlineData("cbdgef", 9)]
    public void Decode_signal_patterns(string signalPattern, int digitValue)
    {
        // Arrange
        const string signalPatterns = "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb";

        // Act
        var digits = Digit.Parse(signalPatterns);

        // Assert
        digits.Should().Contain(new Digit(digitValue, signalPattern));
    }
}