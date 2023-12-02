using System.Linq;

namespace AdventOfCode._2020.Day02
{
    public class PasswordPositionPolicy : IPasswordPolicy
    {
        private readonly char character;
        private readonly int firstPosition;
        private readonly int secondPosition;

        public PasswordPositionPolicy(
            int firstPosition,
            int secondPosition,
            char character)
        {
            this.firstPosition = firstPosition;
            this.secondPosition = secondPosition;
            this.character = character;
        }

        public bool Validate(string password)
        {
            var validity = false;
            if (password.ElementAt(firstPosition - 1) == character)
                validity = !validity;

            if (password.ElementAt(secondPosition - 1) == character)
                validity = !validity;

            return validity;
        }
    }
}