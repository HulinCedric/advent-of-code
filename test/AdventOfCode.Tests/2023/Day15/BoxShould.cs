using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day15;

public class BoxShould
{
    [Fact]
    public void Not_when_no_lens_inside()
    {
        var box = new Box(3);
        box.ToString().Should().BeEmpty();
    }

    [Fact]
    public void Print_when_lens_inside()
    {
        var box = new Box(3);
        box.Add("pc 4");
        box.ToString().Should().Be("Box 3: [pc 4]");
    }

    [Fact]
    public void Print_when_multiple_lens_inside()
    {
        var box = new Box(3);
        box.Add("pc 4");
        box.Add("ot 9");
        box.ToString().Should().Be("Box 3: [pc 4] [ot 9]");
    }

    [Fact]
    public void Replace_lens_with_same_label()
    {
        var box = new Box(3);
        box.Add("ot 9");
        box.Add("ab 5");
        box.Add("pc 6");

        box.Add("ot 7");

        box.ToString().Should().Be("Box 3: [ot 7] [ab 5] [pc 6]");
    }

    [Fact]
    public void Remove_labeled_lens()
    {
        var box = new Box(3);
        box.Add("pc 4");
        box.Add("ot 9");
        box.Add("ab 5");

        box.RemoveLensWithLabel("pc");

        box.ToString().Should().Be("Box 3: [ot 9] [ab 5]");
    }

    [Fact]
    public void Calculate_focusing_power()
    {
        var box = new Box(3);
        box.Add("ot 7");
        box.Add("ab 5");
        box.Add("pc 6");

        box.FocusingPower().Should().Be(140);
    }
}