using Xunit;

namespace AdventOfCode._2020.Day01
{
    public class ReportRepairShould
    {
        [Theory]
        [InlineData("1721\n979\n366\n299\n675\n1456", 514579)]
        [InputFileData("2020/Day01/input.txt", 787776)]
        public void Fix_expense_report_with_two_entries(
            string expenseReportDescription,
            int expectedFixedExpenseReportValue)
        {
            //When
            var fixedExpenseReportValue = ReportRepair.GetFixedExpenseReportValueWithTwoEntries(expenseReportDescription);

            //Then
            Assert.Equal(expectedFixedExpenseReportValue, fixedExpenseReportValue);
        }

        [Theory]
        [InlineData("1721\n979\n366\n299\n675\n1456", 241861950)]
        [InputFileData("2020/Day01/input.txt", 262738554)]
        public void Fix_expense_report_with_three_entries(
            string expenseReportDescription,
            int expectedFixedExpenseReportValue)
        {
            //When
            var fixedExpenseReportValue = ReportRepair.GetFixedExpenseReportValueWithThreeEntries(expenseReportDescription);

            //Then
            Assert.Equal(expectedFixedExpenseReportValue, fixedExpenseReportValue);
        }
    }
}