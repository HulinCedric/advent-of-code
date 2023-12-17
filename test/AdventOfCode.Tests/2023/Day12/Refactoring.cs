using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day12;

public class Refactoring
{
    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 4)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 1)]
    [InlineData("????.######..#####. 1,6,5", 4)]
    [InlineData("?###???????? 3,2,1", 10)]
    public void FindAName(
        string springsConditionRecord,
        int arrangements)
    {
        var springRow = SpringConditionRecordExtensions.Parse(springsConditionRecord);
        Arrangements(springRow)
            .Should()
            .Be(arrangements);
    }

    private static long Arrangements(SpringConditionRecord conditionRecord)
        => Compute(
            conditionRecord.Springs,
            ImmutableStack.CreateRange(conditionRecord.ContiguousGroupOfDamagedSprings.Reverse()));

    private static long Compute(string initialPattern, ImmutableStack<int> initialNums)
    {
        var stack = new Stack<(string pattern, ImmutableStack<int> nums)>();
        stack.Push((initialPattern, initialNums));

        long totalArrangements = 0;

        while (stack.Count > 0)
        {
            var (pattern, nums) = stack.Pop();

            switch (pattern.FirstOrDefault())
            {
                case '.':
                    stack.Push((pattern[1..], nums));
                    break;
                case '?':
                    stack.Push(("." + pattern[1..], nums));
                    stack.Push(("#" + pattern[1..], nums));
                    break;
                case '#':
                    if (!nums.Any())
                    {
                        break;
                    }

                    var n = nums.Peek();
                    nums = nums.Pop();

                    var potentiallyDead = pattern.TakeWhile(s => s is '#' or '?').Count();

                    if (potentiallyDead < n)
                    {
                        break;
                    }

                    if (pattern.Length == n)
                    {
                        stack.Push(("", nums));
                        break;
                    }

                    if (pattern[n] == '#')
                    {
                        break;
                    }

                    stack.Push((pattern[(n + 1)..], nums));
                    break;
                default:
                    totalArrangements += nums.Any() ? 0 : 1;
                    break;
            }
        }

        return totalArrangements;
    }

    private static long ProcessEnd(string _, ImmutableStack<int> nums)
        // the good case is when there are no numbers left at the end of the pattern
        => nums.Any() ? 0 : 1;

    private static long ProcessDot(string pattern, ImmutableStack<int> nums)
        // consume one spring and recurse
        => Compute(pattern[1..], nums);

    private static long ProcessQuestion(string pattern, ImmutableStack<int> nums)
        // recurse both ways
        => Compute("." + pattern[1..], nums) + Compute("#" + pattern[1..], nums);

    private static long ProcessHash(string pattern, ImmutableStack<int> nums)
    {
        // take the first number and consume that many dead springs, recurse

        if (!nums.Any())
        {
            return 0; // no more numbers left, this is no good
        }

        var n = nums.Peek();
        nums = nums.Pop();

        var potentiallyDead = pattern.TakeWhile(s => s is '#' or '?').Count();

        if (potentiallyDead < n)
        {
            return 0; // not enough dead springs 
        }

        if (pattern.Length == n)
        {
            return Compute("", nums);
        }

        if (pattern[n] == '#')
        {
            return 0; // dead spring follows the range -> not good
        }

        return Compute(pattern[(n + 1)..], nums);
    }
}