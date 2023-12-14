using System.Linq;

namespace AdventOfCode._2023.Day09;

public static class StepPredictionExtensions
{
    public static long ExtrapolateNextStep(this long[] steps)
    {
        if (steps.All(step => step == 0))
        {
            return 0;
        }

        return steps.Differences().ExtrapolateNextStep() + steps.Last();
    }
}