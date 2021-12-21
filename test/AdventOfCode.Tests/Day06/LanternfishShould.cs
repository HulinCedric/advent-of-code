using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day06;

public class LanternfishShould
{
    [Theory]
    [InlineData("3,4,3,1,2", 5934)]
    [InputFileData("Day06/input.txt", 352195)]
    public void How_many_lanternfish_would_there_be_after_80_days(
        string lanternfishInternalTimerValues,
        int expectedLanternfishCount)
    {
        // Given
        var lanternfishs = new Lanternfishs(
            lanternfishInternalTimerValues.Split(",")
                .Select(int.Parse)
                .Select(lanternfishInternalTimerValue => new Lanternfish(lanternfishInternalTimerValue))
                .ToArray());

        // When
        while (lanternfishs.CurrentDay < 81)
            lanternfishs.PassADay();

        // Then
        lanternfishs.CurrentDay.Should().Be(81);
        lanternfishs.Count().Should().Be(expectedLanternfishCount);
    }


    [Theory]
    [InlineData(8, 7)]
    [InlineData(7, 6)]
    [InlineData(6, 5)]
    [InlineData(5, 4)]
    [InlineData(4, 3)]
    [InlineData(3, 2)]
    [InlineData(2, 1)]
    [InlineData(1, 0)]
    public void Decrease_internal_timer_by_one_when_a_day_pass_and_its_value_is(
        int internalTimerValue,
        int expectedInternalValue)
    {
        // Given
        var expectedDaySummary = new LanternfishDaySummary(expectedInternalValue, null);
        var lanternfish = new Lanternfish(internalTimerValue);

        // When
        var daySummary = lanternfish.PassADay();

        // Then
        daySummary.Should().Be(expectedDaySummary);
    }

    [Fact]
    public void Increase_internal_timer_to_6_when_a_day_pass_and_its_value_is_0()
    {
        // Given
        const int expectedInternalValue = 6;
        var expectedDaySummary = new LanternfishDaySummary(expectedInternalValue, new Lanternfish(8));
        var lanternfish = new Lanternfish(0);

        // When
        var daySummary = lanternfish.PassADay();

        // Then
        daySummary.Should().Be(expectedDaySummary);
    }

    [Fact]
    public void Give_a_new_lanternfish_with_internal_value_of_8_when_a_day_pass_and_its_value_is_0()
    {
        // Given
        const int expectedInternalValue = 6;
        var expectedDaySummary = new LanternfishDaySummary(expectedInternalValue, new Lanternfish(8));
        var lanternfish = new Lanternfish(0);

        // When
        var daySummary = lanternfish.PassADay();

        // Then
        daySummary.Should().Be(expectedDaySummary);
    }
}