using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode._2023.Day12;

using Cache = Dictionary<(string, ImmutableStack<int>), long>;

public static class SpringConditionRecordArrangementExtensions
{
    internal static long Arrangements(string pattern, ImmutableStack<int> nums, Cache cache)
    {
        var key = (pattern, nums);
        if (cache.TryGetValue(key, out var value))
        {
            return value;
        }

        return cache[key] = Dispatch(pattern, nums, cache);
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
        if (!HasNumbersLeft(nums))
        {
            return 0;
        }

        if (NotEnoughDamagedSprings(pattern, nums))
        {
            return 0;
        }

        if (DamagedSpringFollowsRange(pattern, nums))
        {
            return 0;
        }

        var nextPattern = NextPattern(pattern, nums);

        return Arrangements(nextPattern, nums.Pop(), cache);
    }

    private static string NextPattern(string pattern, ImmutableStack<int> nums)
        => IsEnd(pattern, nums) ?
               "" :
               pattern[(nums.Peek() + 1)..];

    private static bool IsEnd(string pattern, ImmutableStack<int> nums)
    {
        var n = nums.Peek();
        return pattern.Length == n;
    }

    private static bool HasNumbersLeft(ImmutableStack<int> nums)
        => nums.Any();

    private static bool NotEnoughDamagedSprings(string pattern, ImmutableStack<int> nums)
    {
        var n = nums.Peek();
        var potentiallyDead = pattern.TakeWhile(s => s is Spring.Damaged or Spring.Unknown).Count();
        return potentiallyDead < n;
    }

    private static bool DamagedSpringFollowsRange(string pattern, ImmutableStack<int> nums)
    {
        var n = nums.Peek();
        return pattern.Length > n && pattern[n] == Spring.Damaged;
    }
}