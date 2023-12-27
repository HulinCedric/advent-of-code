using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day15;

public class LensLibrary
{
    private const int BoxesInLibrary = 256;
    private readonly List<Box> boxes;
    private readonly Dictionary<char, Action<Box, Step>> operations;

    private LensLibrary(List<Box> boxes)
    {
        this.boxes = boxes;
        operations = new Dictionary<char, Action<Box, Step>>
        {
            { '=', AddLens },
            { '-', RemoveLens }
        };
    }

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
            ExecuteOperation(step, box);
        }
    }

    private void ExecuteOperation(Step step, Box box)
        => operations[step.Operation](box, step);

    private Box FindCorrespondingBox(Step step)
        => boxes[step.BoxNumber()];

    private static void AddLens(Box box, Step step)
        => box.Add(step.Label + " " + step.FocalLength);

    private static void RemoveLens(Box box, Step step)
        => box.RemoveLensWithLabel(step.Label);

    public int FocusingPower()
        => boxes.Sum(box => box.FocusingPower());
}