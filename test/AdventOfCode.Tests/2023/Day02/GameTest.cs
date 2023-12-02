using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day02;

public class GamesTest
{
    [Theory]
    [InputFileData("2023/Day02/sample.txt", 8)]
    [InputFileData("2023/Day02/input.txt", 1734)]
    public void What_is_the_sum_of_the_ids_of_possible_games(
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

    // fewest number of cubes of each color
    [Theory]
    [InputFileData("2023/Day02/sample.txt", 2286)]
    [InputFileData("2023/Day02/input.txt", 70387)]
    public void What_is_the_sum_of_the_power_of_all_games(
        string gamesInformation,
        int expectedSumOfPower)
        => Game.ParseMany(gamesInformation)
            .Select(game => game.PossibleHand())
            .Sum(hand => hand.Power())
            .Should()
            .Be(expectedSumOfPower);

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void Is_Possible(string gameInformation, bool isPossible)
        => Game.Parse(gameInformation)
            .IsPossible()
            .Should()
            .Be(isPossible);
}