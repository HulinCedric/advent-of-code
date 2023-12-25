using System.Collections.Generic;

namespace AdventOfCode._2023.Day13;

public class Map : Dictionary<Position, char>
{
    public Map(IEnumerable<KeyValuePair<Position, char>> toDictionary) : base(toDictionary)
    {
    }
}