using System.Collections.Generic;

namespace AdventOfCode._2023.Day05;

public static class QueueExtensions
{
    public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> source)
    {
        foreach (var item in source)
        {
            queue.Enqueue(item);
        }
    }
}