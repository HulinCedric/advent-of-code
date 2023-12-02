using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day02;

public class GamesTest
{
    [Theory]
    [InputFileData("2023/Day02/sample.txt", 8)]
    [InputFileData("2023/Day02/input.txt", 1734)]
    public void What_is_the_sum_of_the_ids_of_those_games(
        string gamesInformation,
        int expectedSumOfPossibleGameIds)
    {
        // Given
        var games = Game.ParseMany(gamesInformation);

        // When
        var sumOfPossibleGameIds = games
            .Where(game => game.IsPossible())
            .Sum(game => game.Id);

        // Then
        sumOfPossibleGameIds.Should().Be(expectedSumOfPossibleGameIds);
    }

    [Theory]
    [InputFileData("2023/Day02/sample.txt", 2286)]
    [InputFileData("2023/Day02/input.txt", 70387)]
    public void What_is_the_sum_of_the_power_of_these_sets(
        string gamesInformation,
        int expectedSumOfPossibleGameIds)
    {
        // Given
        var games = Game.ParseMany(gamesInformation);

        // When
        var sumOfPossibleGameIds = games
            .Sum(game => game.Power());

        // Then
        sumOfPossibleGameIds.Should().Be(expectedSumOfPossibleGameIds);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void Is_Possible(string gameInformation, bool isPossible)
    {
        // Given
        var game = Game.Parse(gameInformation);

        // Then
        game.IsPossible().Should().Be(isPossible);
    }
}

public record Game
{
    private Game(int id, List<Hand> hands)
    {
        Id = id;
        Hands = hands;
    }

    public List<Hand> Hands { get; }

    public int Id { get; }

    public static List<Game> ParseMany(string gamesInformation)
        => gamesInformation.Split('\n').Select(Parse).ToList();

    public static Game Parse(string gameInformation)
    {
        var gameInformationParts = gameInformation.Split(":");

        var id = int.Parse(gameInformationParts[0].Replace("Game ", ""));

        var hands = Hand.ParseMany(gameInformationParts[1]);

        return new Game(id, hands);
    }

    public bool IsPossible()
        => Hands.All(x => x.Cubes.All(c => c.IsPossible()));

    public int Power()
    {
        // max count by color
        var fewestNumberOfCubesByColor =
            Hands
                .SelectMany(hand => hand.Cubes)
                .GroupBy(cubes => cubes.Color)
                .Select(g => g.Max(cubes => cubes.Count));

        // multiply all
        return fewestNumberOfCubesByColor.Aggregate(1, (current, next) => current * next);
    }
}

public class Hand
{
    private Hand(List<Cubes> cubes)
        => Cubes = cubes;

    public List<Cubes> Cubes { get; }

    public static List<Hand> ParseMany(string handsInformation)
    {
        var cubesSets = handsInformation.Trim().Split(";", StringSplitOptions.TrimEntries);

        return cubesSets.Select(Parse).ToList();
    }

    private static Hand Parse(string handInformation)
        => new(
            handInformation
                .Split(",", StringSplitOptions.TrimEntries)
                .Select(Day02.Cubes.Parse)
                .ToList());
}

public class Cubes
{
    private Cubes(int count, string color)
    {
        Count = count;
        Color = color;
    }

    public string Color { get; }
    public int Count { get; }

    public static Cubes Parse(string cubeHandInformation)
    {
        var parts = cubeHandInformation.Split(" ", StringSplitOptions.TrimEntries);

        return new Cubes(int.Parse(parts[0]), parts[1]);
    }

    public bool IsPossible()
        => Color switch
        {
            "red" => Count <= 12,
            "green" => Count <= 13,
            "blue" => Count <= 14,
            _ => false
        };
}