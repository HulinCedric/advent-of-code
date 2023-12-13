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


    public Hand(List<Card> cards)
    {
        this.cards = cards;
        Value = ComputeHandValue(cards, cards, HandTypes);
    }

    public Hand(List<Card> originalCards, List<Card> handTypeCards)
    {
        cards = originalCards;
        Value = ComputeHandValue(originalCards, handTypeCards, HandTypes);
    }

    private HandValue Value { get; }

    public int CompareTo(Hand? opponent)
        => opponent is null ? 1 : Value.CompareTo(opponent.Value);

    private static HandValue ComputeHandValue(
        List<Card> originalCards,
        List<Card> handTypeCards,
        IList<IHandType> handTypes)
    {
        var handTypeStrength = handTypeCards.TypeStrength(handTypes);
        var handOrderingStrength = originalCards.OrderingStrength();
        return new HandValue(handTypeStrength, handOrderingStrength);
    }
    
    public override string ToString()
        => $"{string.Join(" ", cards)} : {Value}";
}