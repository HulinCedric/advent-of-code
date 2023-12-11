using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day06;

public static class MathExtensions
{
    public static int Multiply(this IEnumerable<int> value)
        => value.Aggregate(1, (a, b) => a * b);
}