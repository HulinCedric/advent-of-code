using System.Linq;

namespace AdventOfCode._2023.Day09;

public static class ReportParser
{
    public static long[][] ParseReport(this string report)
        => report.Split('\n').Select(ParseStepHistory).ToArray();

    private static long[] ParseStepHistory(this string stepHistory)
        => stepHistory.Split(' ').Select(long.Parse).ToArray();
}