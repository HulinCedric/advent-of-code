using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day07;

public class HandShoud
{
    [Theory]
    [InlineData("32T3K", "KTJJT")]
    [InlineData("KTJJT", "KK677")]
    [InlineData("KK677", "T55J5")]
    [InlineData("T55J5", "QQQJA")]
    [InlineData("QQQJA", "22222")]
    [InlineData("AA23A", "AAAKK")]
    [InlineData("AAAKK", "22223")]
    [InlineData("AAAAK", "22222")]
    public void Weakest(
        string firstHand,
        string secondHand)
        => Hand.Parse(firstHand).Should().BeLessThan(Hand.Parse(secondHand));

    [Theory]
    [InlineData("33332", "2AAAA")]
    [InlineData("77888", "77788")]
    public void Strongest(
        string firstHand,
        string secondHand)
        => Hand.Parse(firstHand).Should().BeGreaterThan(Hand.Parse(secondHand));
}

public class Hand : IComparable<Hand>
{
    private static readonly List<IHandType> HandTypes =
    [
        new HighCard(),
        new OnePair(),
        new TwoPairs(),
        new ThreeOfKinds(),
        new FullHouse(),
        new FourOfKinds(),
        new FiveOfKinds()
    ];

    private Hand(List<Card> cards)
        => Value = ComputeHandValue(cards, HandTypes);

    private HandValue Value { get; }

    public int CompareTo(Hand? opponent)
        => opponent is null ? 1 : Value.CompareTo(opponent.Value);

    public static Hand Parse(string hand)
        => new(hand.ToCharArray().Select(Card.Parse).ToList());

    private static HandValue ComputeHandValue(List<Card> cards, IList<IHandType> handTypes)
    {
        var handTypeStrength = cards.TypeStrength(handTypes);
        var handOrderingStrength = cards.OrderingStrength();
        return new HandValue(handTypeStrength, handOrderingStrength);
    }
}

public readonly record struct HandValue
{
    private readonly long handOrderingStrength;
    private readonly int handTypeStrength;

    /// <summary>
    ///     <para>
    ///         Hand value is a number composed of hand type strength and the hand ordering strength. Each component value in
    ///         the hand value have weight in order to compare by priority. Here is a repartition schema after weight have been
    ///         apply:
    ///     </para>
    ///     <para>handTypeStrength:   x________</para>
    ///     <para>handOrderingStrength:   _xxxxxxxx</para>
    /// </summary>
    /// <example>
    ///     <code>HandValue(5, 1234567)</code>
    ///     Resulting in: 5_1234567
    /// </example>
    public HandValue(int handTypeStrength, long handOrderingStrength)
    {
        this.handTypeStrength = handTypeStrength;
        this.handOrderingStrength = handOrderingStrength;

        Value = (handTypeStrength, handOrderingStrength);
    }

    private (int, long) Value { get; }

    public int CompareTo(HandValue opponent)
        => Value.CompareTo(opponent.Value);

    public override string ToString()
        => $"{handTypeStrength} : {handOrderingStrength} = {Value}";
}

public interface IHandType
{
    bool IsMatch(IEnumerable<Card> cards);
}

public class FiveOfKinds : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards
            .ThatHaveSameLabel()
            .AndNumberOfCardsIs(5)
            .Any();
}

public class FourOfKinds : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Quadruplet().Count() == 1;
}

public class FullHouse : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Pair().Count() == 1 &&
           cards.Triplet().Count() == 1;
}

public class ThreeOfKinds : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Triplet().Count() == 1;
}

public class TwoPairs : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Pair().Count() == 2;
}

public class OnePair : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Pair().Count() == 1;
}

public class HighCard : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Count() == cards.Select(card => card.Label).Distinct().Count();
}

public static class HandExtensions
{
    public static IEnumerable<IGrouping<char, Card>> ThatHaveSameLabel(this IEnumerable<Card> cards)
        => cards
            .GroupBy(c => c.Label);

    public static IEnumerable<IGrouping<T, Card>> AndNumberOfCardsIs<T>(
        this IEnumerable<IGrouping<T, Card>> groupOfCards,
        int numberOfCards)
        => groupOfCards.Where(g => g.Count() == numberOfCards);

    public static int OrderingStrength(this IEnumerable<Card> cards)
        => cards.Aggregate(1, (total, card) => total * Card.StrongestValue + card.Value);

    public static int TypeStrength(this IEnumerable<Card> cards, IList<IHandType> handTypes)
        => (from handType in handTypes
            let handTypeStrength = handTypes.IndexOf(handType)
            where handType.IsMatch(cards)
            select handTypeStrength).Max();

    public static IEnumerable<IGrouping<char, Card>> Pair(this IEnumerable<Card> cards)
        => cards
            .ThatHaveSameLabel()
            .AndNumberOfCardsIs(2);

    public static IEnumerable<IGrouping<char, Card>> Triplet(this IEnumerable<Card> cards)
        => cards
            .ThatHaveSameLabel()
            .AndNumberOfCardsIs(3);

    public static IEnumerable<IGrouping<char, Card>> Quadruplet(this IEnumerable<Card> cards)
        => cards
            .ThatHaveSameLabel()
            .AndNumberOfCardsIs(4);
}