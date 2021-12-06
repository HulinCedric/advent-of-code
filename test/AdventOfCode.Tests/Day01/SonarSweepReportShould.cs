using System.Linq;
using Xunit;

namespace AdventOfCode.Day01
{
    public class SonarSweepReportShould
    {
        [Theory]
        [InlineData("199\n200\n208\n210\n200\n207\n240\n269\n260\n263", 7)]
        [InputFileData("Day01/input.txt", 1581)]
        public void How_many_measurements_are_larger_than_the_previous_measurement(
            string sonarSweepReportDescription,
            int expectedLargerMeasurementCount)
        {
            //When
            var measurements = sonarSweepReportDescription.Split('\n').Select(ushort.Parse).ToArray();

            var largerMeasurementCount = 0;
            var previousMeasurement = measurements.First();
            foreach (var measurement in measurements)
            {
                if (measurement > previousMeasurement)
                    largerMeasurementCount++;

                previousMeasurement = measurement;
            }

            //Then
            Assert.Equal(expectedLargerMeasurementCount, largerMeasurementCount);
        }
    }
}