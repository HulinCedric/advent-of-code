using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day14.Map;

namespace AdventOfCode._2023.Day14;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day14/sample.txt", 136)]
    [InputFileData("2023/Day14/input.txt", 109_755)]
    public void Calculate_total_load_of_tilted_map(string map, int measure)
        => SupportBeam.TotalLoad(Parse(map).Tilt()).Should().Be(measure);

    [Theory]
    [InputFileData("2023/Day14/sample.txt", 64)]
    [InputFileData("2023/Day14/input.txt", 90_928)]
    public void Calculate_total_load_of_cycled_map(string map, int measure)
        => SupportBeam.TotalLoad(RunSpinCycle(Parse(map), 1_000_000_000)).Should().Be(measure);


    private static Map RunSpinCycle(Map map, int cycleNumber)
    {
        var cache = new List<string>();
        while (cycleNumber > 0)
        {
            map = SpinCycle(map);
            cycleNumber--;

            var mapSignature = map.ToString();
            var index = cache.IndexOf(mapSignature);
            if (index == -1)
            {
                cache.Add(mapSignature);
            }
            else
            {
                var loopLength = cache.Count - index;
                var remainder = cycleNumber % loopLength;
                return Parse(cache[index + remainder]);
            }
        }

        return map;
    }

    private static Map SpinCycle(Map map)
    {
        for (var i = 0; i < 4; i++)
        {
            map = map.Tilt().Rotate();
        }

        return map;
    }
}