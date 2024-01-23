using System.Threading.Tasks;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using static AdventOfCode._2023.Day13.MapParser;
using static VerifyXunit.Verifier;

namespace AdventOfCode._2023.Day13;

public class MapShould
{
    [Theory]
    [InputFileData("2023/Day13/sample1.txt")]
    [InputFileData("2023/Day13/sample2.txt")]
    public async Task Be_parse(string input)
        => await Verify(Parse(input)).UseParameters(input);

    [Theory]
    [InputFileData("2023/Day13/sample.txt")]
    public async Task Parse_many(string input)
        => await Verify(ParseMany(input)).UseParameters(input);

    [Theory]
    [InputFileData("2023/Day13/sample1.txt", 0, 5)]
    public void Find_mirror_with_vertical_pattern_reflection(
        string input,
        int mirrorRowPosition,
        int mirrorColumnPosition)
        => Parse(input)
            .MirrorPosition()
            .Should()
            .Be(new Position(mirrorRowPosition, mirrorColumnPosition));

    [Theory]
    [InputFileData("2023/Day13/sample2.txt", 4, 0)]
    public void Find_mirror_with_horizontal_pattern_reflection(
        string input,
        int mirrorRowPosition,
        int mirrorColumnPosition)
        => Parse(input)
            .MirrorPosition()
            .Should()
            .Be(new Position(mirrorRowPosition, mirrorColumnPosition));
}