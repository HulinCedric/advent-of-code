using System;

namespace AdventOfCode._2023.Day03;

internal static class PartFactory
{
    internal static TPart Create<TPart>(string text, int rowIndex, int columnIndex) where TPart : Part
    {
        if (typeof(TPart) == typeof(Number))
        {
            return (TPart)(object)new Number(text, rowIndex, columnIndex);
        }

        if (typeof(TPart) == typeof(Symbol))
        {
            return (TPart)(object)new Symbol(text, rowIndex, columnIndex);
        }

        if (typeof(TPart) == typeof(Gear))
        {
            return (TPart)(object)new Gear(text, rowIndex, columnIndex);
        }

        throw new ArgumentException($"Unsupported type: {typeof(TPart)}");
    }
}