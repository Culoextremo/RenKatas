


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
    
    [Test]
    public void sdfsdf()
    {
        var sut = new Player(new Card(Color.Green, 3));
        var doc = new Table(new Card(Color.Yellow, 7));
        sut.CanThrowOn(doc)
            .Should().Be(false);
    }
    
    [Test]
    public void dfgd()
    {
        var sut = new Player(new Card(Color.Green, 3));
        var doc = new Table(new Card(Color.Yellow, 3));
        sut.CanThrowOn(doc)
            .Should().Be(true);
    }
    
}

public class Player
{
    private readonly Card[] hand;

    public Player(params Card[] cards)
    {
        this.hand = cards;
    }

    public bool CanThrowOn(Table table)
    {
        return hand.Single().CanBeThrownOnTopOf(table.CardOnTop);
    }
}