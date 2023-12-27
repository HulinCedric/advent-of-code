namespace AdventOfCode._2023.Day15;

internal record Lens(string Label, string FocalLength)
{
    public override string ToString()
        => Label + " " + FocalLength;

    public bool AsSameLabelAs(Lens other)
        => AsLabel(other.Label);

    public bool AsLabel(string label)
        => Label == label;
}