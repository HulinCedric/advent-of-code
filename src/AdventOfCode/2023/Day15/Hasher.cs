namespace AdventOfCode._2023.Day15;

public class Hasher
{
    /// <summary>
    ///     - Determine the ASCII code for the current character of the string.
    ///     - Increase the current value by the ASCII code you just determined.
    ///     - Set the current value to itself multiplied by 17.
    ///     - Set the current value to the remainder of dividing itself by 256.
    /// </summary>
    public static int Hash(string characters)
    {
        var hash = 0;
        foreach (var character in characters.ToCharArray())
        {
            hash += character;
            hash *= 17;
            hash %= 256;
        }

        return hash;
    }
}