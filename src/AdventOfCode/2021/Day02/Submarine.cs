using AdventOfCode._2021.Day02.AimCommands;
using AdventOfCode._2021.Day02.Commands;

namespace AdventOfCode._2021.Day02
{
    public class Submarine
    {
        public Submarine()
            : this(0, 0, new Aim(0))
        {
        }

        public Submarine(int horizontal, int depth)
            : this(horizontal, depth, new Aim(0))
        {
        }


        public Submarine(Aim aim)
            : this(0, 0, aim)
        {
        }

        public Submarine(int horizontal, int depth, Aim aim)
        {
            Position = new Position(horizontal, depth);
            Aim = aim;
        }

        public Aim Aim { get; private set; }

        public Position Position { get; private set; }

        public void Execute(SubmarineCommand command)
            => Position = command.ExecuteFor(Position);

        public void Execute(SubmarineAimCommand command)
            => (Position, Aim) = command.ExecuteFor(this);
    }
}