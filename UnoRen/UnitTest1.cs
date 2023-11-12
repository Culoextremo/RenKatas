


using FluentAssertions;

namespace UnoRen;

public class Tests
{
    [Test]
    public void CanThrowOnCardWithSameColor()
    {
        var sut = new Card(Color.Yellow, 4);
        sut.CanBeThrownOnTopOf(new Card(Color.Yellow, 7))
            .Should().BeTrue();
    }

    [Test]
    public void CanThrowOnCardWithSameNumber()
    {
        var sut = new Card(Color.Yellow, 4);
        sut.CanBeThrownOnTopOf(new Card(Color.Green, 4))
            .Should().BeTrue();
    }

    [Test]
    public void CanThrowOnCardWithDifferentColorAndNumber()
    {
        var sut = new Card(Color.Yellow, 8);
        sut.CanBeThrownOnTopOf(new Card(Color.Green, 4))
            .Should().BeFalse();
    }
    
    [Test]
    public void DefaultTableCard()
    {
        var sut = new Table(new Card(Color.Yellow, 3));
        sut.CardOnTop.Should().Be(new Card(Color.Yellow, 3));
    }
    
}

public class Table
{
    public Table(Card card)
    {
        CardOnTop = card;
    }

    public Card CardOnTop { get; set; }
}

public enum Color
{
    Yellow,
    Green
}