using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day06;

public class LanternfishsShould
{
    [Fact]
    public void Pass_a_day_for_all_lanternfish()
    {
        // Given
        var expectedDaySummary = new LanternfishsDaySummary(
            1,
            new LanternfishDaySummary(1, null),
            new LanternfishDaySummary(3, null));
        var lanternfishs = new Lanternfishs(new Lanternfish(2), new Lanternfish(4));

        // When
        var daySummary = lanternfishs.PassADay();

        // Then
        daySummary.Should().BeEquivalentTo(expectedDaySummary);
    }

    [Fact]
    public void Add_newly_created_lanternfish_at_the_end_without_passing_day_on_it()
    {
        // Given
        var lanternfishs = new Lanternfishs(new Lanternfish(0));

        // When
        lanternfishs.PassADay();

        // Then
        lanternfishs
            .Should()
            .HaveCount(2)
            .And.Subject.Last()
            .Should()
            .Be(new Lanternfish(8));
    }
}