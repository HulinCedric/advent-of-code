using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day12;

using Cache = Dictionary<(string, ImmutableStack<int>), long>;

public class PuzzleTest
{
    [Theory]
    [InputFileData("2023/Day12/sample.txt", 1, 21)]
    [InputFileData("2023/Day12/input.txt", 1, 6981L)]
    [InputFileData("2023/Day12/sample.txt", 5, 525152)]
    [InputFileData("2023/Day12/input.txt", 5, 4546215031609L)]
    public void Count_all_possible_arrangements(
        string springsConditionRecords,
        int repeat,
        long arrangements)
        => Puzzle.Solve(springsConditionRecords, repeat)
            .Should()
            .Be(arrangements);
}

public static class Puzzle
{
    public static long Solve(string input, int repeat)
    {
        var cache = new Cache();
        return (from line in input.Split("\n")
                let parts = line.Split(" ")
                let pattern = SpringConditionRecordExtensions.Unfold(parts[0], '?', repeat)
                let numString = SpringConditionRecordExtensions.Unfold(parts[1], ',', repeat)
                let nums = numString.Split(',').Select(int.Parse)
                select
                    Arrangements(pattern, ImmutableStack.CreateRange(nums.Reverse()), cache)).Sum();
    }

    private static long Arrangements(string pattern, ImmutableStack<int> nums, Cache cache)
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