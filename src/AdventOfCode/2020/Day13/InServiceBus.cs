namespace AdventOfCode._2020.Day13
{
    public class InServiceBus
        : Bus
    {
        public InServiceBus(int id)
            => Id = id;

        /// <summary>
        ///     ID also indicates how often the bus leaves for the airport.
        /// </summary>
        public int Id { get; }

        public long GetNextDepartTimestamp(long timestamp)
            => Id * (timestamp / Id + 1);

        public long GetCommonDepartureTimestamp(int busPosition, long timestamp, long increment)
        {
            while (!IsDepartureTimestamp(timestamp, busPosition))
                timestamp += increment;
            return timestamp;
        }

        private bool IsDepartureTimestamp(long timestamp, int busPosition)
        {
            var modValue = Id - busPosition % Id;
            return timestamp % Id == modValue;
        }
    }
}