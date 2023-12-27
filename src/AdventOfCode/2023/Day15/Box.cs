using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day15;

public class Box
{
    private readonly List<Lens> lenses;
    private readonly int number;

    public Box(int number)
    {
        this.number = number;
        lenses = new List<Lens>();
    }

    public override string ToString()
    {
        if (lenses.Count == 0)
        {
            return "";
        }

        return "Box " + number + ": [" + string.Join("] [", lenses) + "]";
    }

    public void Add(string lensInfo)
    {
        var parts = lensInfo.Split(' ');

        var lens = new Lens(parts[0], parts[1]);

        var existingLabeledLens = lenses.FirstOrDefault(l => l.AsSameLabelAs(lens));
        if (existingLabeledLens != null)
        {
            var indexOfExistingLens = lenses.IndexOf(existingLabeledLens);

            lenses.Insert(indexOfExistingLens, lens);
            lenses.RemoveAt(indexOfExistingLens + 1);
        }
        else
        {
            lenses.Add(lens);
        }
    }

    public void RemoveLensWithLabel(string label)
    {
        var existingLabeledLens = lenses.FirstOrDefault(l => l.AsLabel(label));
        if (existingLabeledLens == null)
        {
            return;
        }

        var indexOfExistingLens = lenses.IndexOf(existingLabeledLens);
        lenses.RemoveAt(indexOfExistingLens);
    }
}