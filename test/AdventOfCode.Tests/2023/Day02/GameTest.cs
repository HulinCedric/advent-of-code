using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;

namespace AdventOfCode._2023.Day02;

[UsesVerify]
public class GamesTest
{
    [Theory]
    [InputFileData("2023/Day02/sample.txt", 8)]
    public void What_is_the_sum_of_the_ids_of_those_games(
        string gamesInformation,
        int expectedSumOfPossibleGameIds)
    {
        // Given
        var games = Games.Parse(gamesInformation);

        // When
        var sumOfPossibleGameIds = games.Values
            .Where(game => game.IsPossible())
            .Sum(game => game.Id);

        // Then
        sumOfPossibleGameIds.Should().Be(expectedSumOfPossibleGameIds);
    }

    [Theory]
    [InputFileData("2023/Day02/sample.txt")]
    public Task Parse_games(string gamesInformation)
        => Verify(Games.Parse(gamesInformation));

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void Is_valid(string gameInformation, bool isPossible)
    {
        // Given
        var game = Game.Parse(gameInformation);

        // Then
        game.IsPossible().Should().Be(isPossible);
    }
}

public class Games
{
    private Games(List<Game> values)
        => Values = values;

    public List<Game> Values { get; }


    public static Games Parse(string gamesInformation)
        => new(gamesInformation.Split('\n').Select(Game.Parse).ToList());
}

public record Game
{
    private Game(int id, CubeSets cubeSets)
    {
        Id = id;
        CubeSets = cubeSets;
    }

    public CubeSets CubeSets { get; }
    public int Id { get; }

    public static Game Parse(string gameInformation)
    {
        var gameInformationParts = gameInformation.Split(":");

        var id = int.Parse(gameInformationParts[0].Replace("Game ", ""));

        var hands = CubeSets.Parse(gameInformationParts[1]);

        return new Game(id, hands);
    }

    public bool IsPossible()
        => CubeSets.Values.All(x => x.Cubes.All(c => c.IsPossible()));
}

public class CubeSets
{
    private CubeSets(List<CubeSubsets> values)
        => Values = values;

    public List<CubeSubsets> Values { get; }

    public static CubeSets Parse(string handsInformation)
    {
        var cubesSets = handsInformation.Trim().Split(";", StringSplitOptions.TrimEntries);

        var cubesSubSets = cubesSets.Select(CubeSubsets.Parse).ToList();

        return new CubeSets(cubesSubSets);
    }
}

public class CubeSubsets
{
    private CubeSubsets(List<Cubes> cubes)
        => Cubes = cubes;

    public List<Cubes> Cubes { get; }

    public static CubeSubsets Parse(string s)
    {
        var cubes = s.Split(",", StringSplitOptions.TrimEntries).Select(Day02.Cubes.Parse).ToList();


        return new CubeSubsets(cubes);
    }
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
    {
        if (Color == "red")
            return Count <= 12;

        if (Color == "green")
            return Count <= 13;

        if (Color == "blue")
            return Count <= 14;

        return false;
    }
}