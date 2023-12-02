namespace AdventOfCode._2020.Day13
{
    public static class MathExtension
    {
        /// <summary>
        ///     https://en.wikipedia.org/wiki/Greatest_common_divisor
        /// </summary>
        private static long GetGreatestCommonDivisor(long a, long b)
        {
            while (b != 0) b = a % (a = b);
            return a;
        }

        /// <summary>
        ///     https://en.wikipedia.org/wiki/Least_common_multiple
        /// </summary>
        public static long GetLeastCommonMultiple(long a, long b)
            => a * b / GetGreatestCommonDivisor(a, b);
    }
}