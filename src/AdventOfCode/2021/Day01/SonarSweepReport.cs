using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    public static class SonarSweepReport
    {
        public static int CountLargerMeasurements(List<Measurement> measurements)
        {
            var largerMeasurementCount = 0;
            var previousMeasurement = measurements.First();

            foreach (var measurement in measurements)
            {
                if (measurement > previousMeasurement)
                    largerMeasurementCount++;

                previousMeasurement = measurement;
            }

            return largerMeasurementCount;
        }

        public static List<Measurement> GetMeasurements(string sonarSweepReportDescription, int measurementWindowSize)
            => sonarSweepReportDescription
                .Split('\n')
                .Select(ushort.Parse)
                .Window(measurementWindowSize)
                .Select(windowValue => new Measurement(windowValue))
                .ToList();
    }
}