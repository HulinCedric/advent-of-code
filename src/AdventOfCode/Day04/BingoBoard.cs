using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04;

public class BingoBoard
{
    private readonly BoardNumber[][] numbers;

    public BingoBoard(IEnumerable<int[]> numbers)
        => this.numbers = numbers
               .Select(rowNumbers => rowNumbers.Select(number => new BoardNumber(number)).ToArray())
               .ToArray();

    public bool HasWon
        => ContainWinningSet(NumbersByRow) || ContainWinningSet(NumbersByColumn);

    public IEnumerable<int> MarkedNumbers
        => numbers.SelectMany(rowNumbers => rowNumbers)
            .Where(number => number.IsMarked)
            .Select(number => number.Value);

    private IEnumerable<IEnumerable<BoardNumber>> NumbersByColumn
        => numbers.SelectMany(
                (rowNumbers, rowIndex) => rowNumbers
                    .Select((number, columnIndex) => new { number, columnIndex, rowIndex }))
            .GroupBy(flatten => flatten.columnIndex)
            .Select(
                numbersGroupedByColumn => numbersGroupedByColumn
                    .Select(flatten => flatten.number));

    private IEnumerable<IEnumerable<BoardNumber>> NumbersByRow
        => numbers;

    public int WinningScore { get; private set; }

    private int ComputeWinningScore(int winNumber)
    {
        var sumOfUnmarkedNumbers = numbers.SelectMany(rowNumbers => rowNumbers)
            .Where(number => number.IsUnmarked)
            .Sum(number => number.Value);

        return sumOfUnmarkedNumbers * winNumber;
    }

    private static bool ContainWinningSet(IEnumerable<IEnumerable<BoardNumber>> numberSet)
        => numberSet.Any(rowNumbers => rowNumbers.All(number => number.IsMarked));

    public void Mark(int drawNumber)
    {
        foreach (var rowNumbers in numbers)
        foreach (var number in rowNumbers)
            if (number.Value == drawNumber)
                number.IsMarked = true;

        if (HasWon && WinningScore == 0)
            WinningScore = ComputeWinningScore(drawNumber);
    }

    private record BoardNumber(int Value)
    {
        internal bool IsMarked { get; set; }

        internal bool IsUnmarked
            => !IsMarked;
    }
}