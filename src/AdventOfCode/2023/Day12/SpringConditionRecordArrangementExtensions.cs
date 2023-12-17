using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode._2023.Day12;

using Cache = Dictionary<(string, ImmutableStack<int>), long>;

public static class SpringConditionRecordArrangementExtensions
{
    internal static long Arrangements(string pattern, ImmutableStack<int> nums, Cache cache)
    {
        if (!cache.ContainsKey((pattern, nums)))
        {
            cache[(pattern, nums)] = Dispatch(pattern, nums, cache);
        }

        return cache[(pattern, nums)];
    }

    private static long Dispatch(string pattern, ImmutableStack<int> nums, Cache cache)
        => pattern.FirstOrDefault() switch
        {
            Spring.Operational => ProcessOperational(pattern, nums, cache),
            Spring.Unknown => ProcessUnknown(pattern, nums, cache),
            Spring.Damaged => ProcessDamaged(pattern, nums, cache),
            _ => ProcessEnd(pattern, nums, cache)
        };

    private static long ProcessEnd(string _, ImmutableStack<int> nums, Cache __)
        // the good case is when there are no numbers left at the end of the pattern
        => nums.Any() ? 0 : 1;

    private static long ProcessOperational(string pattern, ImmutableStack<int> nums, Cache cache)
        // consume one spring and recurse
        => Arrangements(pattern[1..], nums, cache);

    private static long ProcessUnknown(string pattern, ImmutableStack<int> nums, Cache cache)
        // recurse both ways
        => Arrangements(Spring.Operational + pattern[1..], nums, cache) +
           Arrangements(Spring.Damaged + pattern[1..], nums, cache);

    private static long ProcessDamaged(string pattern, ImmutableStack<int> nums, Cache cache)
    {
        // take the first number and consume that many dead springs, recurse

        if (!nums.Any())
        {
            return 0; // no more numbers left, this is no good
        }

        var n = nums.Peek();
        nums = nums.Pop();

        var potentiallyDead = pattern.TakeWhile(s => s is Spring.Damaged or Spring.Unknown).Count();

        if (potentiallyDead < n)
        {
            return 0; // not enough dead springs 
        }

        if (pattern.Length == n)
        {
            return Arrangements("", nums, cache);
        }

        if (pattern[n] == Spring.Damaged)
        {
            return 0; // dead spring follows the range -> not good
        }

        return Arrangements(pattern[(n + 1)..], nums, cache);
    }
}