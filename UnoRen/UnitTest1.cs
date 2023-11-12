


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

    [Test]
    public void ThrowCardOnTop()
    {
        var sut = new Table(new Card(Color.Yellow, 3));

        sut.Throw(new Card(Color.Yellow, 7));

        sut.CardOnTop.Should().Be(new Card(Color.Yellow, 7));
    }
}

public class Table
{
    public Table(Card card)
    {
        CardOnTop = card;
    }

    public Card CardOnTop { get; private set; }

    public void Throw(Card card)
    {
        CardOnTop = card;
    }
}

public enum Color
{
    Yellow,
    Green
}