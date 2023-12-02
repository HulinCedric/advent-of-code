using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day15
{
    public class MemoryGame
    {
        private const int FirstTimeSpokenNumberMet = 0;
        private readonly Dictionary<int, int> spokenNumbersTurns;
        private int lastSpokenNumber;

        public MemoryGame(string startingNumbersDescription)
        {
            var startingNumbers = startingNumbersDescription
                .Split(',')
                .Select(int.Parse)
                .ToList();

            spokenNumbersTurns = startingNumbers
                .SkipLast(1)
                .Select((spokenNumber, turn) => (spokenNumber, turn))
                .ToDictionary(tuple => tuple.spokenNumber, tuple => tuple.turn);

            lastSpokenNumber = startingNumbers.Last();
        }

        private int CurrentTurn
            => spokenNumbersTurns.Values.Max() + 2;

        private int NextTurn
            => CurrentTurn + 1;

        public MemoryGameState State
            => new(CurrentTurn, lastSpokenNumber);

        public void Play()
            => PlayUpToTurn(NextTurn);

        public void PlayUpToTurn(int expectedTurn)
        {
            for (var turn = spokenNumbersTurns.Count; turn < expectedTurn - 1; turn++)
            {
                var spokenNumber = ComputeSpokenNumberForTurn(turn);

                spokenNumbersTurns[lastSpokenNumber] = turn;
                lastSpokenNumber = spokenNumber;
            }
        }

        private int ComputeSpokenNumberAge(int turn, int spokenNumber)
            => turn - GetTurnForSpokenNumber(spokenNumber);

        private int ComputeSpokenNumberForTurn(int turn)
            => IsNumberAlreadySpoken(lastSpokenNumber) ?
                ComputeSpokenNumberAge(turn, lastSpokenNumber) :
                FirstTimeSpokenNumberMet;

        private int GetTurnForSpokenNumber(int spokenNumber)
            => spokenNumbersTurns[spokenNumber];

        private bool IsNumberAlreadySpoken(int number)
            => spokenNumbersTurns.ContainsKey(number);
    }
}