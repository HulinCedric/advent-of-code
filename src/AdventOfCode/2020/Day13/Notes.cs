using System.Collections.Generic;

namespace AdventOfCode._2020.Day13
{
    public class Notes
    {
        public Notes(int earliestDepartureTimestamp, IEnumerable<Bus> buses)
        {
            EarliestDepartureTimestamp = earliestDepartureTimestamp;
            Buses = buses;
        }

        public int EarliestDepartureTimestamp { get; }
        public IEnumerable<Bus> Buses { get; }
    }
}