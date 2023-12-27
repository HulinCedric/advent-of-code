using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day15;

public class Box
{
    private readonly List<Lens> lenses;
    public int Number { get; }

    public Box(int number)
    {
        this.Number = number;
        lenses = new List<Lens>();
    }

    public override string ToString()
    {
        if (lenses.Count == 0)
        {
            return "";
        }

        return "Box " + Number + ": [" + string.Join("] [", lenses) + "]";
    }

    public void Add(Lens lens)
    {
        var existing = lenses.FindIndex(l => l.AsSameLabelAs(lens));
        if (existing != -1)
        {
            lenses[existing] = lens;
        }
        else
        {
            lenses.Add(lens);
        }
    }

    public void RemoveLensWithLabel(string label)
        => lenses.RemoveAll(l => l.AsLabel(label));

    /// <summary>
    ///     The focusing power of a single lens is the result of multiplying together:
    ///     - One plus the box number of the lens in question.
    ///     - The slot number of the lens within the box: 1 for the first lens, 2 for the second lens, and so on.
    ///     - The focal length of the lens.
    /// </summary>
    public int FocusingPower()
        => (from lens in lenses
            let onePlusBoxNumber = 1 + Number
            let slotNumber = lenses.IndexOf(lens) + 1
            let focalLength = lens.FocalLength
            select onePlusBoxNumber * slotNumber * focalLength).Sum();
}