namespace AdventOfCode._2020.Day13
{
    public static class BusTimestampCalculator
    {
        /// <summary>
        ///     Visualization: https://streamable.com/tojflp
        /// </summary>
        public static (long, long) ComputeCommonDepartureTimestamp(
            InServiceBus bus,
            int busPosition,
            long earliestTimestamp,
            long increment)
            => (
                bus.GetCommonDepartureTimestamp(busPosition, earliestTimestamp, increment),
                MathExtension.GetLeastCommonMultiple(increment, bus.Id));
    }
}