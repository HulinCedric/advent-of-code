using System;
using AdventOfCode._2020.Day12.Ships;

namespace AdventOfCode._2020.Day12.NavigationInstructions
{
    public abstract record NavigationInstruction(char Action, int Value)
    {
        public static NavigationInstruction CreateInstance(char action, int value)
            => action switch
            {
                'N' => new NorthNavigationInstruction(action, value),
                'S' => new SouthNavigationInstruction(action, value),
                'E' => new EastNavigationInstruction(action, value),
                'W' => new WestNavigationInstruction(action, value),
                'L' => new LeftNavigationInstruction(action, value),
                'R' => new RightNavigationInstruction(action, value),
                'F' => new ForwardNavigationInstruction(action, value),
                _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
            };

        public abstract void Execute(Ship ship);
    }
}