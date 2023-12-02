using System.Linq;

namespace AdventOfCode._2020.Day02
{
    public class PasswordOccurrencePolicy : IPasswordPolicy
    {
        private readonly int atLeast;
        private readonly int atMost;
        private readonly char character;

        public PasswordOccurrencePolicy(
            int atLeast,
            int atMost,
            char character)
        {
            this.atLeast = atLeast;
            this.atMost = atMost;
            this.character = character;
        }
        // refactor: Rename variable to suppress warning 
        public bool Validate(string password)
        {
            var characterCount = ComputeCharacterCount(password);
            return atLeast <= characterCount && characterCount <= atMost;
        }

        private int ComputeCharacterCount(string password)
            => password
            .GroupBy(passwordCharacter => passwordCharacter)
            .Where(groupedCharacters => groupedCharacters.Key == character)
            .Select(c => c.Count())
            .SingleOrDefault();
    }
}