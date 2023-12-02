namespace AdventOfCode._2020.Day02
{
    public static class PasswordFactory
    {
        public static Password CreatePasswordWithOccurrencePolicy(string passwordAndPolicyDescriptions)
            => new(
                GetPassword(passwordAndPolicyDescriptions),
                new PasswordOccurrencePolicy(
                    GetFirstParameterPolicy(passwordAndPolicyDescriptions),
                    GetSecondParameterPolicy(passwordAndPolicyDescriptions),
                    GetCharacter(passwordAndPolicyDescriptions)));

        public static Password CreatePasswordWithPositionPolicy(string passwordAndPolicyDescriptions)
            => new(
                GetPassword(passwordAndPolicyDescriptions),
                new PasswordPositionPolicy(
                    GetFirstParameterPolicy(passwordAndPolicyDescriptions),
                    GetSecondParameterPolicy(passwordAndPolicyDescriptions),
                    GetCharacter(passwordAndPolicyDescriptions)));

        private static int GetFirstParameterPolicy(string passwordAndPolicyDescriptions)
            => int.Parse(passwordAndPolicyDescriptions[..IndexOfPolicySeparator(passwordAndPolicyDescriptions)]);

        private static int GetSecondParameterPolicy(string passwordAndPolicyDescriptions)
            => int.Parse(passwordAndPolicyDescriptions[(IndexOfPolicySeparator(passwordAndPolicyDescriptions) + 1)..IndexOfCharacterSeparator(passwordAndPolicyDescriptions)]);

        private static char GetCharacter(string passwordAndPolicyDescriptions)
            => char.Parse(passwordAndPolicyDescriptions[(IndexOfCharacterSeparator(passwordAndPolicyDescriptions) + 1)..IndexOfPasswordSeparator(passwordAndPolicyDescriptions)]);

        private static string GetPassword(string passwordAndPolicyDescriptions)
            => passwordAndPolicyDescriptions[(IndexOfPasswordSeparator(passwordAndPolicyDescriptions) + 1)..];

        private static int IndexOfCharacterSeparator(string passwordAndPolicyDescriptions)
            => passwordAndPolicyDescriptions.IndexOf(' ');

        private static int IndexOfPasswordSeparator(string passwordAndPolicyDescriptions)
            => passwordAndPolicyDescriptions.IndexOf(':');

        private static int IndexOfPolicySeparator(string passwordAndPolicyDescriptions)
            => passwordAndPolicyDescriptions.IndexOf('-');
    }
}