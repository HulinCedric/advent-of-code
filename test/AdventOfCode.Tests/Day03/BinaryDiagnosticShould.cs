using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day03
{
    public class BinaryDiagnosticShould
    {
        [Theory]
        [InlineData("00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010", 198)]
        [InputFileData("Day03/input.txt", 4103154)]
        public void What_is_the_power_consumption_of_the_submarine(
            string diagnosticReportRepresentation,
            int expectedPowerConsumption)
        {
            // Given
            var diagnosticReport = new DiagnosticReport(diagnosticReportRepresentation);

            // When
            var actualPowerConsumption = diagnosticReport.PowerConsumption;

            // Then
            actualPowerConsumption.Should().Be(expectedPowerConsumption);
        }
        
        [Theory]
        [InlineData("00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010", 230)]
        [InputFileData("Day03/input.txt", 4245351)]
        public void What_is_the_life_support_rating_of_the_submarine(
            string diagnosticReportRepresentation,
            int expectedLifeSupportRating)
        {
            // Given
            var diagnosticReport = new DiagnosticReport(diagnosticReportRepresentation);

            // When
            var actualLifeSupportRating = diagnosticReport.LifeSupportRating;

            // Then
            actualLifeSupportRating.Should().Be(expectedLifeSupportRating);
        }
    }
}