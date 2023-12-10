using System;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace AdventOfCode._2023.Day06;

public class Test
{
    [Theory]
    [InputFileData("2023/Day06/sample.txt", 288)]
    //[InputFileData("2023/Day06/input.txt", 288)]
    public void todoSample(string info, int expected)
    {
        // Arrange
        var races = new[]
        {
            new Race(7, 9),
            new Race(15, 40),
            new Race(30, 200)
        };

        var waysToBeatTheRecord = races.Select(r => r.CalculateWaysToWin()).Aggregate(1, (a, b) => a * b);

        waysToBeatTheRecord.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(6, 6)]
    [InlineData(7, 7)]
    public void Boat_Speed_IncreasesWith_TimeHoldingButton_by_OneMillimeterPerMillisecond(int holdTime, int speed)
    {
        // Arrange
        var boat = new Boat();

        // Act
        boat.HoldButton(holdTime.Milliseconds());

        // Assert
        boat.Speed.Should().Be(speed.MillimetersPerMillisecond());
    }

    [Theory]
    [InlineData(0, 7, 0)]
    [InlineData(1, 6, 6)]
    [InlineData(2, 5, 10)]
    [InlineData(3, 4, 12)]
    [InlineData(4, 3, 12)]
    [InlineData(5, 2, 10)]
    [InlineData(6, 1, 6)]
    [InlineData(7, 0, 0)]
    public void Boat_Move_IncreasesDistance(int holdTimeIn, int moveTimeIn, int distanceIn)
    {
        // Arrange
        var boat = new Boat();
        boat.HoldButton(holdTimeIn.Milliseconds());

        // Act
        boat.Move(moveTimeIn.Milliseconds());

        // Assert
        boat.Distance.Should().Be(distanceIn.Millimeters());
    }


    [Theory]
    [InlineData(7, 9, 4)]
    [InlineData(15, 40, 8)]
    [InlineData(30, 200, 9)]
    public void Race_CalculateWaysToWin_ReturnsCorrectNumber(int time, int distance, int waysToWin)
        => new Race(time, distance)
            .CalculateWaysToWin()
            .Should()
            .Be(waysToWin);
}

public record Race(int Time, int Distance)
{
    public int CalculateWaysToWin()
    {
        var waysToWin = 0;
        for (var i = 0; i < Time; i++)
        {
            var boat = new Boat();
            boat.HoldButton(i.Milliseconds());

            var timeLeftForTheRace = Time - i;

            boat.Move(timeLeftForTheRace.Milliseconds());

            if (boat.Distance > Distance)
            {
                waysToWin++;
            }
        }

        return waysToWin;
    }
}

public class Boat
{
    public Boat()
    {
        Speed = 0;
        Distance = 0;
    }

    public int Distance { get; private set; }

    public int Speed { get; private set; }

    public void HoldButton(TimeSpan time)
        // 1 millisecond = 1 millimeter per millisecond
        => Speed = (int)time.TotalMilliseconds;

    public void Move(TimeSpan time)
        => Distance += Speed * (int)time.TotalMilliseconds;
}

public static class LangExtensions
{
    public static int MillimetersPerMillisecond(this int value)
        => value;

    public static int Millimeters(this int value)
        => value;
}