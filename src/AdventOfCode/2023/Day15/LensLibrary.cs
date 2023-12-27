using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day15;

public class LensLibrary
{
    private const int BoxesInLibrary = 256;
    private readonly List<Box> boxes;

    private LensLibrary(List<Box> boxes)
        => this.boxes = boxes;

    public static LensLibrary Create()
        => new(
            Enumerable.Range(0, BoxesInLibrary)
                .Select(boxNumber => new Box(boxNumber))
                .ToList());

    public void Execute(IEnumerable<Step> steps)
    {
        foreach (var step in steps)
        {
            var box = FindCorrespondingBox(step);
            step.Execute(box);
        }
    }

    private Box FindCorrespondingBox(Step step)
        => boxes.First(box => box.Number == step.BoxNumber());

    public int FocusingPower()
        => boxes.Sum(box => box.FocusingPower());
}