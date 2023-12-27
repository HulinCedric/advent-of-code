using System.Collections.Generic;
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


    [Theory]
    [InlineData("rn=1", 0)]
    [InlineData("cm-", 0)]
    [InlineData("qp=3", 1)]
    [InlineData("cm=2", 0)]
    [InlineData("qp-", 1)]
    [InlineData("pc=4", 3)]
    [InlineData("ot=9", 3)]
    public void Should_determine_box_number_for_initialization_step(string initializationStep, int result)
        => BoxNumber(Parse(initializationStep)).Should().Be(result);


    [Fact]
    public void Should_not_print_box_when_no_lens_inside()
    {
        var box = new Box(3);
        box.ToString().Should().BeEmpty();
    }

    [Fact]
    public void Should_print_box_when_lens_inside()
    {
        var box = new Box(3);
        box.Add("pc 4");
        box.ToString().Should().Be("Box 3: [pc 4]");
    }

    [Fact]
    public void Should_print_box_when_multiple_lens_inside()
    {
        var box = new Box(3);
        box.Add("pc 4");
        box.Add("ot 9");
        box.ToString().Should().Be("Box 3: [pc 4] [ot 9]");
    }

    private InitializationStep Parse(string initializationStep)
    {
        var parts = initializationStep.Split('=', '-');

        var label = parts[0];

        var isDash = parts[1] == "";
        char operation;
        int? focalLength;
        if (isDash)
        {
            operation = '-';
            focalLength = null;
        }
        else
        {
            operation = '=';
            focalLength = int.Parse(parts[1]);
        }

        return new InitializationStep(
            label,
            operation,
            focalLength);
    }

    private static int BoxNumber(InitializationStep initializationStep)
        => Hash(initializationStep.Label);

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

public class Box
{
    private readonly List<string> lenses;
    private readonly int number;


    public Box(int number)
    {
        this.number = number;
        lenses = new List<string>();
    }

    public override string ToString()
    {
        if (lenses.Count == 0)
        {
            return "";
        }


        if (lenses.Count == 1)
        {
            return "Box " + number + ": [" + lenses.First() + "]";
        }

        return "Box " + number + ": [" + lenses.First() + "] [" + lenses.Last() + "]";
    }

    public void Add(string lens)
        => lenses.Add(lens);
}

internal readonly record struct InitializationStep(string Label, char Operation, int? FocalLength);