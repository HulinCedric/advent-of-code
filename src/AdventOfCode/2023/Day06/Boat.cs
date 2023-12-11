using System;

namespace AdventOfCode._2023.Day06;

public class Boat
{
    public Boat()
    {
        Speed = 0;
        Distance = 0;
    }

    public long Distance { get; private set; }

    public int Speed { get; private set; }

    public void HoldButton(TimeSpan time)
        => Speed = (int)time.TotalMilliseconds;

    public void Move(TimeSpan time)
        => Distance += Speed * (long)time.TotalMilliseconds;
}