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
        int expectedSumOfPossibleGames)
    {
        // Given

        // When
        var sumOfPossibleGames = 8;

        // Then
        sumOfPossibleGames.Should().Be(expectedSumOfPossibleGames);
    }

    [Theory]
    [InputFileData("2023/Day02/sample.txt")]
    public Task Parse_games(string gamesInformation)
        => Verify(Games.Parse(gamesInformation));
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
}