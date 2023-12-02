namespace AdventOfCode._2020.Day08.Runners
{
    public record ProgramExecutionResult(
        int AccumulatorValue,
        bool IsProgramTerminates,
        bool IsInfiniteLoop);
}