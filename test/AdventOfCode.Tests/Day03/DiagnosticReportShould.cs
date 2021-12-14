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
        
        [Theory]
        [InlineData("00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010", 23)]
        public void Generate_oxygen_generator_rating(
            string diagnosticReportRepresentation,
            int expectedOxygenGeneratorRating)
        {
            // Given
            var diagnosticReport = new DiagnosticReport(diagnosticReportRepresentation);

            // When
            var actualOxygenGeneratorRating = diagnosticReport.OxygenGeneratorRating;

            // Then
            actualOxygenGeneratorRating.Should().Be(expectedOxygenGeneratorRating);
        }
        
        [Theory]
        [InlineData("00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010", 10)]
        public void Generate_CO2_scrubber_rating(
            string diagnosticReportRepresentation,
            int expectedCo2ScrubberRating)
        {
            // Given
            var diagnosticReport = new DiagnosticReport(diagnosticReportRepresentation);

            // When
            var actualCo2ScrubberRating = diagnosticReport.Co2ScrubberRating;

            // Then
            actualCo2ScrubberRating.Should().Be(expectedCo2ScrubberRating);
        }
    }
}