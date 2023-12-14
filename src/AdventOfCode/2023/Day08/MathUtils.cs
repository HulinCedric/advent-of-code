namespace AdventOfCode._2023.Day08;

public static class MathUtils
{
    /// <seealso href="https://en.wikipedia.org/wiki/Least_common_multiple#Using_the_greatest_common_divisor" />
    public static long LeastCommonMultiple(long a, long b)
        => a / GreatestCommonDivisor(a, b) * b;

    /// <seealso href="https://en.wikipedia.org/wiki/Euclidean_algorithm#Implementations" />
    private static long GreatestCommonDivisor(long a, long b)
        => b == 0 ? a : GreatestCommonDivisor(b, a % b);
}