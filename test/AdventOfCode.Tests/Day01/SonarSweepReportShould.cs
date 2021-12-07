using System;
using System.Collections.Generic;
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

        [Theory]
        [InlineData("199\n200\n208\n210\n200\n207\n240\n269\n260\n263", 5)]
        [InputFileData("Day01/input.txt", 1618)]
        public void How_many_measurements_are_larger_than_the_previous_sliding_windows_measurement(
            string sonarSweepReportDescription,
            int expectedLargerMeasurementCount)
        {
            //When
            var measurementValues = sonarSweepReportDescription.Split('\n').Select(ushort.Parse).ToArray();

            var measurements = measurementValues.Window(3).Select(w => new Measurement(w)).ToList();

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

    public record Measurement
    {
        private readonly IEnumerable<ushort> values;

        public Measurement(IEnumerable<ushort> values)
            => this.values = values;

        public static bool operator >(Measurement a, Measurement b)
            => a.values.Sum(v => v) > b.values.Sum(v => v);

        public static bool operator <(Measurement a, Measurement b)
            => a.values.Sum(v => v) < b.values.Sum(v => v);
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<IList<TSource>> Window<TSource>(this IEnumerable<TSource> source, int size)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            return _();

            IEnumerable<IList<TSource>> _()
            {
                using var iter = source.GetEnumerator();

                // generate the first window of items
                var window = new TSource[size];
                int i;
                for (i = 0; i < size && iter.MoveNext(); i++)
                    window[i] = iter.Current;

                if (i < size)
                    yield break;

                while (iter.MoveNext())
                {
                    // generate the next window by shifting forward by one item
                    // and do that before exposing the data
                    var newWindow = new TSource[size];
                    Array.Copy(window, 1, newWindow, 0, size - 1);
                    newWindow[size - 1] = iter.Current;

                    yield return window;
                    window = newWindow;
                }

                // return the last window.
                yield return window;
            }
        }
    }
}