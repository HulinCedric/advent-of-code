using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day02;

public class Game
{
    private Game(int id, List<Hand> hands)
    {
        Id = id;
        Hands = hands;
    }

    private List<Hand> Hands { get; }

    public int Id { get; }

    /// <example>
    ///     Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
    ///     Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
    /// </example>
    public static List<Game> ParseMany(string gamesInformation)
        => gamesInformation.Split('\n').Select(Parse).ToList();

    /// <example>Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green</example>
    public static Game Parse(string gameInformation)
    {
        var gameInformationParts = gameInformation.Split(":");

        var id = int.Parse(gameInformationParts[0].Replace("Game ", ""));

        var hands = Hand.ParseMany(gameInformationParts[1]);

        return new Game(id, hands);
    }

    public bool IsPossible()
        => Hands.All(hand => hand.Cubes.All(cubes => cubes.IsPossible()));

    public Hand MaxPossibleHand()
        => new(
            Hands
                .SelectMany(hand => hand.Cubes)
                .GroupBy(cubes => cubes.Color)
                .Select(
                    group => group
                        .OrderByDescending(cubes => cubes.Count)
                        .First())
                .ToList());
}