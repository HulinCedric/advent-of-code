using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day02;

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
    [InputFileData("2023/Day02/sample.txt", 5)]
    public void Parse_game_count(
        string gamesInformation,
        int expectedGamesCount)
    {
        // When
        var games = Games.Parse(gamesInformation);

        // Then
        games.Should().HaveCount(expectedGamesCount);
    }
}

public class Games
{
    public static IEnumerable<string> Parse(string gamesInformation)
        => gamesInformation.Split(Environment.NewLine);
}