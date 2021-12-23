using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day06;

public class LanternfishShould
{
    [Theory]
    [InlineData("3,4,3,1,2", 5934L)]
    [InputFileData("Day06/input.txt", 352195L)]
    public void How_many_lanternfish_would_there_be_after_80_days(
        string lanternfishInternalTimerValues,
        long expectedLanternfishCount)
    {
        // Given
        var lanternfishs = new Lanternfishs(
            lanternfishInternalTimerValues.Split(",")
                .Select(int.Parse)
                .ToArray());

        // When
        while (lanternfishs.CurrentDay < 81)
            lanternfishs.PassADay();

        // Then
        lanternfishs.CurrentDay.Should().Be(81);
        lanternfishs.Count().Should().Be(expectedLanternfishCount);
    }

    [Theory]
    [InlineData("3,4,3,1,2", 26984457539L)]
    [InputFileData("Day06/input.txt", 1600306001288L)]
    public void How_many_lanternfish_would_there_be_after_256_days(
        string lanternfishInternalTimerValues,
        long expectedLanternfishCount)
    {
        // Given
        var lanternfishs = new Lanternfishs(
            lanternfishInternalTimerValues.Split(",")
                .Select(int.Parse)
                .ToArray());

        // When
        while (lanternfishs.CurrentDay < 257)
            lanternfishs.PassADay();

        // Then
        lanternfishs.CurrentDay.Should().Be(257);
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
        var lanternfishs = new Lanternfishs(internalTimerValue);

        // When
        lanternfishs.PassADay();

        // Then
        lanternfishs.InternalTimers.First().Should().Be(expectedInternalValue);
    }

    [Fact]
    public void Increase_internal_timer_to_6_when_a_day_pass_and_its_value_is_0()
    {
        // Given
        var lanternfishs = new Lanternfishs(0);

        // When
        lanternfishs.PassADay();

        // Then
        lanternfishs.InternalTimers.First().Should().Be(6);
    }

    [Fact]
    public void Give_a_new_lanternfish_with_internal_value_of_8_when_a_day_pass_and_its_value_is_0()
    {
        // Given
        var lanternfishs = new Lanternfishs(0);

        // When
        lanternfishs.PassADay();

        // Then
        lanternfishs.Count().Should().Be(2);

        lanternfishs.InternalTimers.Should().BeEquivalentTo(new[] { 6, 8 });
    }

    [Fact]
    public void Pass_a_day_for_all_lanternfish()
    {
        // Given
        var lanternfishs = new Lanternfishs(2, 4);

        // When
        lanternfishs.PassADay();

        // Then
        lanternfishs.InternalTimers.Should().BeEquivalentTo(new[] { 1, 3 });
    }
}