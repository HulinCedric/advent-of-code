using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day01
{
    public static class ReportRepair
    {
        private const int TargetedSum = 2020;

        public static int GetFixedExpenseReportValueWithThreeEntries(string expenseReportDescription)
            =>
            (from first in ParseExpenseReport(expenseReportDescription)
             from second in ParseExpenseReport(expenseReportDescription)
             from third in ParseExpenseReport(expenseReportDescription)
             where first + second + third == TargetedSum
             select first * second * third)
            .First();

        public static int GetFixedExpenseReportValueWithTwoEntries(string expenseReportDescription)
            =>
            (from first in ParseExpenseReport(expenseReportDescription)
             from second in ParseExpenseReport(expenseReportDescription)
             where first + second == TargetedSum
             select first * second)
            .First();

        private static IEnumerable<int> ParseExpenseReport(string expenseReportDescription)
            => expenseReportDescription
            .Split("\n")
            .Select(int.Parse);
    }
}