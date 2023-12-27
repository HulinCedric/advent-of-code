using System.Linq;
using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day15.InitializationSequence;

namespace AdventOfCode._2023.Day15;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day15/sample.txt", 1_320)]
    [InputFileData("2023/Day15/input.txt", 520_500)]
    public void Sum_of_the_results(string initializationSequence, int result)
        => Parse(initializationSequence)
            .Select(step => step.Hash())
            .Sum()
            .Should()
            .Be(result);


    [Theory]
    [InputFileData("2023/Day15/sample.txt", 145)]
    [InputFileData("2023/Day15/input.txt", 213_097)]
    public void Sum_of_focusing_power_resulting_lens_configuration(string initializationSequence, int result)
    {
        var steps = Parse(initializationSequence);

        var boxes = Enumerable.Range(0, 256).Select(boxNumber => new Box(boxNumber)).ToList();

        foreach (var step in steps)
        {
            var box = boxes.First(box => box.Number == step.BoxNumber());
            switch (step.Operation)
            {
                case '=':
                    box.Add(step.Label + " " + step.FocalLength);
                    break;
                case '-':
                    box.RemoveLensWithLabel(step.Label);
                    break;
            }
        }

        boxes.Sum(box => box.FocusingPower()).Should().Be(result);
    }
}