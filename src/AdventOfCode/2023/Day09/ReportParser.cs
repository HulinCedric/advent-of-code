using System.Linq;

namespace AdventOfCode._2023.Day09;

public static class ReportParser
{
    public static int[][] ParseReport(this string report)
        => report.Split('\n').Select(ParseStepHistory).ToArray();

    private static int[] ParseStepHistory(this string stepHistory)
        => stepHistory.Split(' ').Select(int.Parse).ToArray();
}