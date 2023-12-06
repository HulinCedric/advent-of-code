using System;
using System.Linq;

namespace AdventOfCode._2023.Day04;

public class ScratchCard
{
    private readonly int[] numbersYouHave;
    private readonly int[] winningNumbers;

    public ScratchCard(int[] winningNumbers, int[] numbersYouHave)
    {
        this.winningNumbers = winningNumbers;
        this.numbersYouHave = numbersYouHave;
    }

    public int GetPoints()
        => (int)Math.Pow(2, Matches() - 1);

    internal int Matches()
        => winningNumbers.Intersect(numbersYouHave).Count();
}