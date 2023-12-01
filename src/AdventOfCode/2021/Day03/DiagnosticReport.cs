using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021.Day03;

public class DiagnosticReport
{
    private readonly string diagnosticReportRepresentation;

    public DiagnosticReport(string diagnosticReportRepresentation)
        => this.diagnosticReportRepresentation = diagnosticReportRepresentation;

    public int Co2ScrubberRating
        => GenerateRating(LeastCommonBit);

    public int EpsilonRate
        => GenerateRate(LeastCommonBit);

    public int GamaRate
        => GenerateRate(MostCommonBit);

    public int LifeSupportRating
        => OxygenGeneratorRating * Co2ScrubberRating;

    public int OxygenGeneratorRating
        => GenerateRating(MostCommonBit);

    public int PowerConsumption
        => GamaRate * EpsilonRate;


    private int GenerateRate(Func<string, char> rateCommonBitStrategy)
    {
        string[] ExtractBinaryNumbers()
            => diagnosticReportRepresentation.Split("\n");

        string BitsAtIndex(IEnumerable<string> binaryNumbers, int index)
            => new(binaryNumbers.Select(binaryNumber => BitAtIndex(binaryNumber, index)).ToArray());

        char BitAtIndex(string binaryNumber, int index)
            => binaryNumber[index];

        var binaryNumbers = ExtractBinaryNumbers();
        var binaryNumberLength = binaryNumbers.First().Length;

        var binaryRate = new StringBuilder();
        for (var index = 0; index < binaryNumberLength; index++)
        {
            var bitsAtIndex = BitsAtIndex(binaryNumbers, index);
            var rateCommonBit = rateCommonBitStrategy(bitsAtIndex);
            binaryRate.Append(rateCommonBit);
        }

        return Convert.ToInt32(binaryRate.ToString(), 2);
    }

    private int GenerateRating(
        Func<IGrouping<char, (string binaryNumber, char bitAtIndex)>,
            IGrouping<char, (string binaryNumber, char bitAtIndex)>,
            IGrouping<char, (string binaryNumber, char bitAtIndex)>[],
            IGrouping<char, (string binaryNumber, char bitAtIndex)>> ratingCommonBitGroupSelectionStrategy)
    {
        string[] ExtractBinaryNumbers()
            => diagnosticReportRepresentation.Split("\n");

        char BitAtIndex(string binaryNumber, int index)
            => binaryNumber[index];

        var binaryNumbers = ExtractBinaryNumbers();
        var binaryNumberLength = binaryNumbers.First().Length;

        for (var index = 0; index < binaryNumberLength && binaryNumbers.Length > 1; index++)
        {
            var binaryNumbersWithBitAtIndex = binaryNumbers
                .Select(binaryNumber => (binaryNumber, bitAtIndex: BitAtIndex(binaryNumber, index)))
                .ToArray();

            var binaryNumbersGroupedByBitAtIndex = binaryNumbersWithBitAtIndex
                .GroupBy(tuple => tuple.bitAtIndex)
                .ToArray();

            var mostCommonBitGroup = binaryNumbersGroupedByBitAtIndex.MaxBy(x => x.Count())!;
            var leastCommonBitGroup = binaryNumbersGroupedByBitAtIndex.MinBy(x => x.Count())!;

            var selectedGroup = ratingCommonBitGroupSelectionStrategy(
                mostCommonBitGroup,
                leastCommonBitGroup,
                binaryNumbersGroupedByBitAtIndex);

            binaryNumbers = selectedGroup.Select(m => m.binaryNumber).ToArray();
        }

        return Convert.ToInt32(binaryNumbers.First(), 2);
    }

    private static char MostCommonBit(string bitsAtIndex)
        => bitsAtIndex.GroupBy(bit => bit).MaxBy(bit => bit.Count())!.Key;

    private static char LeastCommonBit(string bitsAtIndex)
        => bitsAtIndex.GroupBy(bit => bit).MinBy(bit => bit.Count())!.Key;

    private static IGrouping<char, (string binaryNumber, char bitAtIndex)> LeastCommonBit(
        IGrouping<char, (string binaryNumber, char bitAtIndex)> mostCommonBitGroup,
        IGrouping<char, (string binaryNumber, char bitAtIndex)> leastCommonBitGroup,
        IGrouping<char, (string binaryNumber, char bitAtIndex)>[] binaryNumberGroupByBitAtIndex)
        => mostCommonBitGroup.Count() != leastCommonBitGroup.Count()
               ? leastCommonBitGroup
               : binaryNumberGroupByBitAtIndex.First(x => x.Key == '0');

    private static IGrouping<char, (string binaryNumber, char bitAtIndex)> MostCommonBit(
        IGrouping<char, (string binaryNumber, char bitAtIndex)> mostCommonBitGroup,
        IGrouping<char, (string binaryNumber, char bitAtIndex)> leastCommonBitGroup,
        IGrouping<char, (string binaryNumber, char bitAtIndex)>[] binaryNumberGroupByBitAtIndex)
        => mostCommonBitGroup.Count() != leastCommonBitGroup.Count()
               ? mostCommonBitGroup
               : binaryNumberGroupByBitAtIndex.First(x => x.Key == '1');
}