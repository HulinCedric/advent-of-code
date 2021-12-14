using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day03
{
    public class DiagnosticReportShould
    {
        [Theory]
        [InlineData("00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010", 22)]
        public void Generate_gama_rate(
            string diagnosticReportRepresentation,
            int expectedGamaRate)
        {
            // Given
            var diagnosticReport = new DiagnosticReport(diagnosticReportRepresentation);


            // When
            var actualGamaRate = diagnosticReport.GamaRate;

            // Then
            actualGamaRate.Should().Be(expectedGamaRate);
        }
        
        [Theory]
        [InlineData("00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010", 9)]
        public void Generate_epsilon_rate(
            string diagnosticReportRepresentation,
            int expectedEpsilonRate)
        {
            // Given
            var diagnosticReport = new DiagnosticReport(diagnosticReportRepresentation);


            // When
            var actualEpsilonRate = diagnosticReport.EpsilonRate;

            // Then
            actualEpsilonRate.Should().Be(expectedEpsilonRate);
        }
    }
}