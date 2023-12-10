using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace AdventOfCode._2023.Day06;

public class Test
{
    [Theory]
    [InputFileData("2023/Day06/sample.txt", 288)]
    //[InputFileData("2023/Day06/input.txt", 288)]
    public void todo(string info, int expected)
    {
        var actual = 288;

        actual.Should().Be(expected);
    }

    // toy boats
    // Holding down the button **charges the boat**
    // releasing the button **allows the boat to move**


    // race
    // the **time** allowed for a race
    // the best **distance** ever recorded in that race

    // - The first race lasts 7 milliseconds. The record distance in this race is 9 millimeters.
    // - The second race lasts 15 milliseconds. The record distance in this race is 40 millimeters.
    // - The third race lasts 30 milliseconds. The record distance in this race is 200 millimeters.


    // First test
    // Your toy boat has a starting speed of **zero millimeters per millisecond**. For each whole millisecond you spend at the
    // beginning of the race holding down the button, the boat's speed increases by **one millimeter per millisecond**.


    // Don't hold the button at all (that is, hold it for **`0` milliseconds**) at the start of the race.
    // The boat won't move; it will have traveled **`0` millimeters** by the end of the race.
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(6, 6)]
    [InlineData(7, 7)]    
    public void BoatSpeedIncreasesWithTimeHoldingButton(int holdTime, int speed)
    {
        // Arrange
        var boat = new Boat();

        // Act
        boat.HoldButton(holdTime.Milliseconds());

        // Assert
        boat.Speed.Should().Be(speed.MillimetersPerMillisecond());
    }
    
    
}

public record Race(int Time, int Distance);

public class Boat
{
    public Boat()
    {
        Speed = 0;
        Distance = 0;
    }

    public int Distance { get; }

    public int Speed { get; private set; }

    public void HoldButton(TimeSpan time)
        // 1 millisecond = 1 millimeter per millisecond
        => Speed = (int)time.TotalMilliseconds;
}

public static class LangExtensions
{
    public static int MillimetersPerMillisecond(this int value)
        => value;
}