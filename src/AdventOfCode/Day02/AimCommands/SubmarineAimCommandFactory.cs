using System;

namespace AdventOfCode.Day02.AimCommands
{
    public abstract class SubmarineAimCommandFactory
    {
        public static SubmarineAimCommand CreateForRepresentation(string commandRepresentation)
        {
            var commandParts = commandRepresentation.Split(" ");

            var commandName = commandParts[0];
            var commandUnit = int.Parse(commandParts[1]);

            return commandName switch
            {
                "forward" => new ForwardAimCommand(commandUnit),
                "down" => new DownAimCommand(commandUnit),
                "up" => new UpAimCommand(commandUnit),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}