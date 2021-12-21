using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day06;

public class Lanternfishs : IEnumerable<Lanternfish>
{
    private readonly List<Lanternfish> lanternfishs;
    public int CurrentDay = 1;

    public Lanternfishs(params Lanternfish[] lanternfishs)
        => this.lanternfishs = lanternfishs.ToList();

    public IEnumerator<Lanternfish> GetEnumerator()
        => lanternfishs.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable)lanternfishs).GetEnumerator();

    public LanternfishsDaySummary PassADay()
    {
        var lanternfishsDaySummary = new LanternfishsDaySummary(
            CurrentDay,
            lanternfishs
                .Select(lanternfish => lanternfish.PassADay())
                .ToArray());

        lanternfishs.AddRange(
            lanternfishsDaySummary.DaySummaries
                .Select(summary => summary.LanternfishCreated)
                .Where(lanternfishCreated => lanternfishCreated is not null)
                .Cast<Lanternfish>());

        CurrentDay++;

        return lanternfishsDaySummary;
    }
}