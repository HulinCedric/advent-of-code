using AdventOfCode._2020.Day12.Ships;

namespace AdventOfCode._2020.Day12.NavigationInstructions
{
    public record EastNavigationInstruction
        : NavigationInstruction
    {
        public EastNavigationInstruction(char action, int value)
            : base(action, value)

        {
        }

        public override void Execute(Ship ship)
            => ship.MoveEst(Value);
    }
}