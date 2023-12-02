namespace AdventOfCode._2020.Day19
{
    public record Match(string Remaining)
    {
        public bool IsFullMatch
            => string.IsNullOrEmpty(Remaining);
    }
}