using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day03;

public class DiagnosticReport
{
    private readonly string diagnosticReportRepresentation;

    public DiagnosticReport(string diagnosticReportRepresentation)
        => this.diagnosticReportRepresentation = diagnosticReportRepresentation;

    public int EpsilonRate
        => GenerateRate(LeastCommonBit);

    public int GamaRate
        => GenerateRate(MostCommonBit);

    public int PowerConsumption
        => GamaRate * EpsilonRate;

    private static char MostCommonBit(string bitsAtIndex)
        => bitsAtIndex.GroupBy(bit => bit).MaxBy(bit => bit.Count())!.Key;

    private static char LeastCommonBit(string bitsAtIndex)
        => bitsAtIndex.GroupBy(bit => bit).MinBy(bit => bit.Count())!.Key;

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
}