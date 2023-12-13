namespace AdventOfCode._2023.Day07;

public readonly record struct HandValue
{
    private readonly long handOrderingStrength;
    private readonly int handTypeStrength;

    /// <summary>
    ///     <para>
    ///         Hand value is a number composed of hand type strength and the hand ordering strength. Each component value in
    ///         the hand value have weight in order to compare by priority. Here is a repartition schema after weight have been
    ///         apply:
    ///     </para>
    ///     <para>handTypeStrength:   x________</para>
    ///     <para>handOrderingStrength:   _xxxxxxxx</para>
    /// </summary>
    /// <example>
    ///     <code>HandValue(5, 1234567)</code>
    ///     Resulting in: 5_1234567
    /// </example>
    public HandValue(int handTypeStrength, long handOrderingStrength)
    {
        this.handTypeStrength = handTypeStrength;
        this.handOrderingStrength = handOrderingStrength;

        Value = (handTypeStrength, handOrderingStrength);
    }

    private (int, long) Value { get; }

    public int CompareTo(HandValue opponent)
        => Value.CompareTo(opponent.Value);

    public override string ToString()
        => $"{handTypeStrength} : {handOrderingStrength} = {Value}";
}