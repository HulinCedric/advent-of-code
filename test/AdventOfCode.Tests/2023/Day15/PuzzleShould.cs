using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day15;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day15/sample.txt", 1_320)]
    [InputFileData("2023/Day15/input.txt", 520_500)]
    public void Sum_of_the_results(string initializationSequence, int result)
        => initializationSequence.Split(',').Select(Hash).Sum().Should().Be(result);


    [Theory]
    [InlineData("H", 200)]
    [InlineData("HASH", 52)]
    public void Should_Hash(string toHash, int result)
        => Hash(toHash).Should().Be(result);

    [Theory]
    [InlineData("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7", 1_320)]
    public void Should_sum_initialization_sequence_hash_steps(string initializationSequence, int result)
        => initializationSequence.Split(',').Select(Hash).Sum().Should().Be(result);

    /// <summary>
    ///     - Determine the ASCII code for the current character of the string.
    ///     - Increase the current value by the ASCII code you just determined.
    ///     - Set the current value to itself multiplied by 17.
    ///     - Set the current value to the remainder of dividing itself by 256.
    /// </summary>
    private static int Hash(string characters)
    {
        var hash = 0;
        foreach (var character in characters.ToCharArray())
        {
            hash += character;
            hash *= 17;
            hash %= 256;
        }

        return hash;
    }
}