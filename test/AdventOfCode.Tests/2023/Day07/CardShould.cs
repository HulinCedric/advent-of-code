using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day07;

public class CardShould
{
    [Theory]
    [InlineData('2', '3')]
    [InlineData('3', '4')]
    [InlineData('4', '5')]
    [InlineData('5', '6')]
    [InlineData('6', '7')]
    [InlineData('7', '8')]
    [InlineData('8', '9')]
    [InlineData('9', 'T')]
    [InlineData('T', 'J')]
    [InlineData('J', 'Q')]
    [InlineData('Q', 'K')]
    [InlineData('K', 'A')]
    public void Be_weakest_than_when_J_as_Jack(char firstCardLabel, char secondCardLabel)
        => Card.Parse(firstCardLabel, Card.LabelsWithJasJack)
            .Should()
            .BeLessThan(Card.Parse(secondCardLabel, Card.LabelsWithJasJack));

    [Theory]
    [InlineData('J', '2')]
    [InlineData('2', '3')]
    [InlineData('3', '4')]
    [InlineData('4', '5')]
    [InlineData('5', '6')]
    [InlineData('6', '7')]
    [InlineData('7', '8')]
    [InlineData('8', '9')]
    [InlineData('9', 'T')]
    [InlineData('T', 'Q')]
    [InlineData('Q', 'K')]
    [InlineData('K', 'A')]
    public void Be_weakest_than_when_J_as_Joker(char firstCardLabel, char secondCardLabel)
        => Card.Parse(firstCardLabel, Card.LabelsWithJasJoker)
            .Should()
            .BeLessThan(Card.Parse(secondCardLabel, Card.LabelsWithJasJoker));
}