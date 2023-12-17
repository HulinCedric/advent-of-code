using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day12;

public class SpringConditionRecordShould
{
    [Theory]
    [InlineData(".#", ".#?.#?.#?.#?.#")]
    public void UnfoldSprings(
        string springsConditionRecord,
        string unfolded)
        => SpringConditionRecordExtensions.Unfold(springsConditionRecord, '?', 5).Should().Be(unfolded);

    [Theory]
    [InlineData("1", "1,1,1,1,1")]
    public void UnfoldDamageRecord(
        string springsConditionRecord,
        string unfolded)
        => SpringConditionRecordExtensions.Unfold(springsConditionRecord, ',', 5).Should().Be(unfolded);

    [Theory]
    [InlineData("???.### 1,1,3", "???.###????.###????.###????.###????.### 1,1,3,1,1,3,1,1,3,1,1,3,1,1,3")]
    public void UnfoldSpringRecord(
        string springsConditionRecord,
        string unfolded)
        => SpringConditionRecordExtensions.Unfold(SpringConditionRecordExtensions.Parse(springsConditionRecord), 5)
            .Should()
            .BeEquivalentTo(SpringConditionRecordExtensions.Parse(unfolded));
}