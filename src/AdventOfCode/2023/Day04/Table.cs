using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day04;

public class Table
{
    public static IEnumerable<ScratchCard> Parse(string table)
        => table.Split('\n')
            .Select(
                cardInformation =>
                {
                    var cardParts = cardInformation.Split(':', '|');

                    var winningNumbers = ParseCardNumber(cardParts[1]);
                    var numberYouHave = ParseCardNumber(cardParts[2]);

                    return new ScratchCard(winningNumbers, numberYouHave);
                });

    private static int[] ParseCardNumber(string cardPart)
        => cardPart
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
}