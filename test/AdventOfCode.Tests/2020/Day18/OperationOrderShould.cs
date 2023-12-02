using System;
using System.Linq;
using Xunit;
using static MoreLinq.Extensions.ScanExtension;
using static MoreLinq.Extensions.RepeatExtension;
using static MoreLinq.Extensions.TakeUntilExtension;

namespace AdventOfCode._2020.Day18
{
    public class OperationOrderShould
    {
        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71L)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51L)]
        [InlineData("2 * 3 + (4 * 5)", 26L)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437L)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240L)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632L)]
        [InputFileData("2020/Day18/input.txt", 4491283311856L)]
        public void Evaluate_expression_left_to_right(
            string expressionDescription,
            long expectedSum)
        {
            // Given

            // When
            var actualSum = expressionDescription.Split("\n")
                .Select(x => Expression.Parse(x).Solve())
                .Sum();

            // Then
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231L)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51L)]
        [InlineData("2 * 3 + (4 * 5)", 46L)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445L)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060L)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340L)]
        [InputFileData("2020/Day18/input.txt", 68852578641904L)]
        public void Evaluate_addition_before_multiplication(
            string expressionDescription,
            long expectedSum)
        {
            // Given

            // When
            var actualSum = expressionDescription
                .Split("\n")
                .Select(OverrideOperatorPriority)
                .Select(x => Expression.Parse(x).Solve())
                .Sum();

            // Then
            Assert.Equal(expectedSum, actualSum);
        }

        private static string OverrideOperatorPriority(string input)
            => "((" +
               input.Replace("(", "((")
                   .Replace(")", "))")
                   .Replace("+", ") + (")
                   .Replace("*", ")) * ((") +
               "))";
    }

    public record Expression(object[] Items)
    {
        private static long GetValue(object expressionOrNumber)
            => expressionOrNumber switch
            {
                Expression e => e.Solve(),
                long l => l,
                _ => throw new ArgumentOutOfRangeException(nameof(expressionOrNumber), expressionOrNumber, null)
            };

        public long Solve()
            => Items.Zip(Items.Append(null).Skip(1))
                .Aggregate(
                    long.MinValue,
                    (acc, next) => next switch
                    {
                        ({ } lhs, _) when acc == long.MinValue => GetValue(lhs),
                        ('+', { } rhs) => acc + GetValue(rhs),
                        ('*', { } rhs) => acc * GetValue(rhs),
                        _ => acc
                    });

        public static Expression Parse(string input)
        {
            var parsers = new Func<char[], (object?, char[])>[]
            {
                ParseDigitExpression,
                ParseOperatorExpression,
                ParseSubExpression,
                ParseSpaceExpression
            };

            var items =
                parsers
                    .Repeat()
                    .Scan((item: (object?)null, remaining: input.ToCharArray()), (acc, next) => next(acc.remaining))
                    .TakeUntil(x => !x.remaining.Any())
                    .Where(x => x.item != null)
                    .Select(x => x.item!);

            return new Expression(items.ToArray());
        }

        private static (object?, char[]) ParseSpaceExpression(char[] str)
            => (null, str[0] == ' ' ? str[1..] : str);

        private static (object?, char[]) ParseSubExpression(char[] str)
        {
            var bracketCount = 0;
            var expr = str.TakeWhile(
                    x => x switch
                         {
                             '(' => ++bracketCount,
                             ')' => --bracketCount,
                             _ => bracketCount
                         } !=
                         0)
                .ToArray();

            return expr.Any()
                       ? (Parse(new string(expr[1..])), str[(expr.Length + 1) ..])
                       : (null, str);
        }

        private static (object?, char[]) ParseOperatorExpression(char[] str)
            => str[0] is '+' or '*' ? (str[0], str[1..]) : (null, str);

        private static (object?, char[]) ParseDigitExpression(char[] str)
        {
            var digits = str.TakeWhile(char.IsDigit).ToArray();
            return long.TryParse(new string(digits), out var num)
                       ? (num, str[digits.Length ..])
                       : (null, str);
        }
    }
}