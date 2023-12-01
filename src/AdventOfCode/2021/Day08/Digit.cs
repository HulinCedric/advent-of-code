using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day08;

public record Digit(int Value, SignalPattern SignalPattern)
{
    public Digit(int value, string signalPattern) : this(value, new SignalPattern(signalPattern))
    {
    }

    public static HashSet<Digit> Parse(string signalPatterns)
    {
        var encodedDigits = signalPatterns.Split(' ');

        // Identify unique digits
        var one = encodedDigits.Single(d => d.Length == 2);

        var four = encodedDigits.Single(d => d.Length == 4);

        var seven = encodedDigits.Single(d => d.Length == 3);

        var eight = encodedDigits.Single(d => d.Length == 7);

        // Identify digit 0 using the fact that it shares a segment with unique digits
        var zero = encodedDigits
            .Single(
                d => d.Length == 6 &&
                     d.Intersect(four).Count() == 3 &&
                     d.Intersect(seven).Count() == 3 &&
                     d.Intersect(eight).Count() == 6);

        // Identify digit 2 using the fact that it shares a segment with unique digits
        var two = encodedDigits
            .Single(
                d => d.Length == 5 &&
                     d.Intersect(four).Count() == 2 &&
                     d.Intersect(seven).Count() == 2 &&
                     d.Intersect(eight).Count() == 5);

        // Identify digit 3 using the fact that it shares a segment with unique digits
        var three = encodedDigits
            .Single(
                d => d.Length == 5 &&
                     d.Intersect(one).Count() == 2 &&
                     d.Intersect(eight).Count() == 5);

        // Identify digit 5 using the fact that it shares a segment with unique digits
        var five = encodedDigits
            .Single(
                d => d.Length == 5 &&
                     d.Intersect(one).Count() == 1 &&
                     d.Intersect(four).Count() == 3 &&
                     d.Intersect(eight).Count() == 5);

        // Identify digit 6 using the fact that it shares a segment with unique digits
        var six = encodedDigits
            .Single(
                d => d.Length == 6 &&
                     d.Intersect(four).Count() == 3 &&
                     d.Intersect(seven).Count() == 2 &&
                     d.Intersect(eight).Count() == 6);

        // Identify digit 5 using the fact that it shares a segment with unique digits
        var nine = encodedDigits
            .Single(
                d => d.Length == 6 &&
                     d.Intersect(one).Count() == 2 &&
                     d.Intersect(four).Count() == 4 &&
                     d.Intersect(eight).Count() == 6);


        return new HashSet<Digit>
        {
            new(0, zero),
            new(1, one),
            new(2, two),
            new(3, three),
            new(4, four),
            new(5, five),
            new(6, six),
            new(7, seven),
            new(8, eight),
            new(9, nine)
        };
    }
}