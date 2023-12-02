using System;
using System.Collections.Generic;
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
    public static IEnumerable<string> Parse(string gamesInformation)
        => gamesInformation.Split(Environment.NewLine);
}