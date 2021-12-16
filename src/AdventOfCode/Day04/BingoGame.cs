using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04;

public class BingoGame
{
    private readonly BingoBoard[] bingoBoards;

    private readonly List<BingoBoard> leaderBoards;

    public BingoGame(BingoBoard[] bingoBoards)
    {
        this.bingoBoards = bingoBoards;
        leaderBoards = new List<BingoBoard>();
    }

    public IEnumerable<int> LeaderBoardScores
        => leaderBoards.Select(l => l.WinningScore);

    public void AnnounceNumber(int drawNumber)
    {
        foreach (var bingoBoard in bingoBoards)
            bingoBoard.Mark(drawNumber);

        var winningBoards = bingoBoards
            .Except(leaderBoards)
            .Where(board => board.HasWon);

        foreach (var winningBoard in winningBoards)
            leaderBoards.Add(winningBoard);
    }
}