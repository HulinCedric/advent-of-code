namespace AdventOfCode._2023.Day15;

public record Lens(string Label, int FocalLength)
{
    public override string ToString()
        => Label + " " + FocalLength;

    public bool AsSameLabelAs(Lens other)
        => AsLabel(other.Label);

    public bool AsLabel(string label)
        => Label == label;

    public static Lens Parse(string lensInformation)
    {
        var parts = lensInformation.Split(' ');

        return new Lens(parts[0], int.Parse(parts[1]));
    }
}