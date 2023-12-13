using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2023.Day07.HandTypes;

namespace AdventOfCode._2023.Day07;

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

    private readonly List<Card> cards;

    private Hand(List<Card> cards)
    {
        this.cards = cards;
        Value = ComputeHandValue(cards, HandTypes);
    }

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
    
    public override string ToString()
        => $"{string.Join(" ", cards)} : {Value}";
}