using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04;

public static class BingoGameFactory
{
    public static (int[], BingoGame) CreateRandomNumbersAndBoardsRepresentation(
        string gameNumbersAndBoardsRepresentation)
    {
        var splitRepresentation = gameNumbersAndBoardsRepresentation.Split("\n\n");

        var randomNumbers = ExtractRandomNumbers(splitRepresentation);

        var bingoBoards = ExtractBingoBoard(splitRepresentation).ToArray();

        return (randomNumbers, new BingoGame(bingoBoards));
    }

    private static IEnumerable<BingoBoard> ExtractBingoBoard(string[] splitRepresentation)
        => splitRepresentation
            .Skip(1)
            .Select(BingoBoardFactory.CreateWithRepresentation);

    private static int[] ExtractRandomNumbers(string[] splitRepresentation)
        => splitRepresentation[0]
            .Split(",")
            .Select(int.Parse)
            .ToArray();
}