using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day15;

public class LensLibraryShould
{
    [Theory]
    [InputFileData("2023/Day15/sample.txt")]
    public void Print(string initializationSequence)
    {
        var steps = InitializationSequence.Parse(initializationSequence);

        var lensLibrary = LensLibrary.Create();

        lensLibrary.Execute(steps);

        lensLibrary.ToString().Should().Be("Box 0: [rn 1] [cm 2]\nBox 3: [ot 7] [ab 5] [pc 6]");
    }
}