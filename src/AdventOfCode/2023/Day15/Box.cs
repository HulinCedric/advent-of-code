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

    /// <summary>
    ///     The focusing power of a single lens is the result of multiplying together:
    ///     - One plus the box number of the lens in question.
    ///     - The slot number of the lens within the box: 1 for the first lens, 2 for the second lens, and so on.
    ///     - The focal length of the lens.
    /// </summary>
    /// <returns></returns>
    public int FocusingPower()
    {
        var boxNumber = 1 + number;

        return lenses.Select((lens, slotIndex) => boxNumber * int.Parse(lens.FocalLength) * (slotIndex + 1)).Sum();
    }
}