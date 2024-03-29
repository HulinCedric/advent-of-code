using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Day07;

public class StuffShould
{
    [Theory]
    [InlineData("16,1,2,0,4,2,7,1,2,14", 37L)]
    [InputFileData("2021/Day07/input.txt", 340987L)]
    public void How_much_fuel_must_they_spend_to_align_to_that_position(
        string positionsDescription,
        long expectedTotalFuelCost)
    {
        // Given
        var positions = ToPositions(positionsDescription);

        // When
        var actualTotalFuelCost = PositionsExtensions.GetCheapestTotalFuelCost(positions);

        // Then
        actualTotalFuelCost.Should().Be(expectedTotalFuelCost);
    }

    [Theory]
    [InlineData("16,1,2,0,4,2,7,1,2,14", 168L)]
    [InputFileData("2021/Day07/input.txt", 96987874L)]
    public void How_much_fuel_must_they_spend_to_align_to_that_position_2(
        string positionsDescription,
        long expectedTotalFuelCost)
    {
        // Given
        var positions = ToPositions(positionsDescription);

        // When
        var actualTotalFuelCost = PositionsExtensions.GetCheapestTotalFuelCost2(positions);

        // Then
        actualTotalFuelCost.Should().Be(expectedTotalFuelCost);
    }
    
    [Theory]
    [InlineData("16,1,2,0,4,2,7,1,2,14", 2)]
    public void Horizontal_position_that_the_crabs_can_align_to_using_the_least_fuel_possible(
        string positionsDescription,
        int expectedChosePosition)
    {
        // Given
        var positions = ToPositions(positionsDescription);

        // When
        var actualChosePosition = positions.Median();

        // Then
        actualChosePosition.Should().Be(expectedChosePosition);
    }

    private static int[] ToPositions(string positionsDescription)
        => positionsDescription.Split(",").Select(int.Parse).ToArray();
}