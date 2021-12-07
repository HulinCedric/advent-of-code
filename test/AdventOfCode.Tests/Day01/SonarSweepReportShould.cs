using Xunit;

namespace AdventOfCode.Day01
{
    public class SonarSweepReportShould
    {
        [Theory]
        [InlineData("199\n200\n208\n210\n200\n207\n240\n269\n260\n263", 1, 7)]
        [InputFileData("Day01/input.txt", 1, 1581)]
        [InlineData("199\n200\n208\n210\n200\n207\n240\n269\n260\n263", 3, 5)]
        [InputFileData("Day01/input.txt", 3, 1618)]
        public void How_many_measurements_are_larger_than_the_previous_measurement(
            string sonarSweepReportDescription,
            int measurementWindowSize,
            int expectedLargerMeasurementCount)
        {
            // Given
            var measurements = SonarSweepReport.GetMeasurements(sonarSweepReportDescription, measurementWindowSize);

            // When
            var largerMeasurementCount = SonarSweepReport.CountLargerMeasurements(measurements);

            // Then
            Assert.Equal(expectedLargerMeasurementCount, largerMeasurementCount);
        }
    }
}