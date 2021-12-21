namespace AdventOfCode.Day06;

public record Lanternfish(int InternalTimer)
{
    private const int ResetLimit = 0;
    private const int ResetValue = 6;
    private const int CreatedValue = 8;

    public int InternalTimer { get; private set; } = InternalTimer;

    public LanternfishDaySummary PassADay()
    {
        Lanternfish? lanternfishCreated = null;
        if (InternalTimer == ResetLimit)
        {
            InternalTimer = ResetValue;
            lanternfishCreated = new Lanternfish(CreatedValue);
        }
        else
        {
            InternalTimer--;
        }

        return new LanternfishDaySummary(InternalTimer, lanternfishCreated);
    }
}