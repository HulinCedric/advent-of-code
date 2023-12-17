using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day12.SpringConditionRecordExtensions;

namespace AdventOfCode._2023.Day12;

public class SpringConditionRecordShould
{
    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 4)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 1)]
    [InlineData("????.######..#####. 1,6,5", 4)]
    [InlineData("?###???????? 3,2,1", 10)]
    public void Count_possible_springs_arrangements(
        string springsConditionRecord,
        int arrangements)
        => SpringConditionRecord(springsConditionRecord)
            .Arrangements()
            .Should()
            .Be(arrangements);

    [Theory]
    [InlineData("???.### 1,1,3", "???.###????.###????.###????.###????.### 1,1,3,1,1,3,1,1,3,1,1,3,1,1,3")]
    public void Be_unfold(
        string folded,
        string unfolded)
        => SpringConditionRecord(folded)
            .Unfold(5)
            .Should()
            .BeEquivalentTo(SpringConditionRecord(unfolded));

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 16384)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 16)]
    [InlineData("????.######..#####. 1,6,5", 2500)]
    [InlineData("?###???????? 3,2,1", 506250)]
    public void Count_possible_springs_unfolded_arrangements(
        string springsConditionRecord,
        int arrangements)
        => SpringConditionRecord(springsConditionRecord)
            .Unfold(5)
            .Arrangements()
            .Should()
            .Be(arrangements);
}