using System.Linq;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;

namespace AdventOfCode._2023.Day13;

[UsesVerify]
public class MapTests
{
    [Theory]
    [InputFileData("2023/Day13/sample1.txt")]
    [InputFileData("2023/Day13/sample2.txt")]
    public async Task Should_parse_map_correctly(string input)
        => await Verify(MapParser.Parse(input)).UseParameters(input);

    [Theory]
    [InputFileData("2023/Day13/sample1.txt")]
    [InputFileData("2023/Day13/sample2.txt")]
    public async Task GetVerticalSlice(string input)
        => await Verify(MapParser.Parse(input).GetVerticalSlice()).UseParameters(input);

    [Theory]
    [InputFileData("2023/Day13/sample1.txt")]
    [InputFileData("2023/Day13/sample2.txt")]
    public async Task GetHorizontalSlice(string input)
        => await Verify(MapParser.Parse(input).GetHorizontalSlice()).UseParameters(input);

    [Theory]
    [InputFileData("2023/Day13/sample1.txt")]
    public async Task FindMirrorVerticalPosition(string input)
        => await Verify(MapParser.Parse(input).GetMirrorPosition().First().ToString()).UseParameters(input);

    [Theory]
    [InputFileData("2023/Day13/sample2.txt")]
    public async Task FindMirrorHorizontalPosition(string input)
        => await Verify(MapParser.Parse(input).GetMirrorPosition().First().ToString()).UseParameters(input);
}