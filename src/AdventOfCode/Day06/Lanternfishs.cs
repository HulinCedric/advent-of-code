using System.Linq;

namespace AdventOfCode.Day06;

public class Lanternfishs
{
    private const int InternalTimerMinimumLimit = 0;
    private const int InternalTimerWhenReset = 6;
    private const int InternalTimerForNewOnes = 8;

    private readonly long[] internalTimersCounts = new long[9];

    public Lanternfishs(params int[] lanternfishInternalTimers)
    {
        foreach (var lanternfishInternalTimer in lanternfishInternalTimers)
            internalTimersCounts[lanternfishInternalTimer]++;

        CurrentDay = 1;
    }

    public int CurrentDay { get; private set; }

    public int[] InternalTimers
        => internalTimersCounts
            .Select((lanternfishCount, internalTimer) => (lanternfishCount, internalTimer))
            .Where(x => x.lanternfishCount != default)
            .Select(x => x.internalTimer)
            .ToArray();

    public void PassADay()
    {
        var createdLanternfishCount = internalTimersCounts[InternalTimerMinimumLimit];

        for (var i = 1; i < internalTimersCounts.Length; i++)
            internalTimersCounts[i - 1] = internalTimersCounts[i];

        internalTimersCounts[InternalTimerForNewOnes] = createdLanternfishCount;

        internalTimersCounts[InternalTimerWhenReset] += createdLanternfishCount;

        CurrentDay++;
    }

    public long Count()
        => internalTimersCounts.Sum();
}