using System;

namespace AdventOfCode._2023.Day06;

public static class LangExtensions
{
    public static int MillimetersPerMillisecond(this int value)
        => value;

    public static int Millimeters(this int value)
        => value;
    
    public static TimeSpan Milliseconds(this int milliseconds)
    {
        return TimeSpan.FromMilliseconds(milliseconds);
    }
}