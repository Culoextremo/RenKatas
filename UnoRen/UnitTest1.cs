


using FluentAssertions;
using FluentAssertions.Execution;

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
    public void PlayerCannotThrowCardOnTable()
    {
        var sut = new Player(new Card(Color.Green, 3));
        var doc = new Table(new Card(Color.Yellow, 7));
        sut.CanThrowOn(doc)
            .Should().Be(false);
    }
    
    [Test]
    public void PlayerCanThrowCardOnTable()
    {
        var sut = new Player(new Card(Color.Green, 3));
        var doc = new Table(new Card(Color.Yellow, 3));
        sut.CanThrowOn(doc)
            .Should().Be(true);
    }
    
    [Test]
    public void PlayerCanThrow_WithMultipleCardsInHand()
    {
        var sut = new Player(new Card(Color.Green, 8), new Card(Color.Yellow, 3));
        var doc = new Table(new Card(Color.Yellow, 3));
        sut.CanThrowOn(doc)
            .Should().Be(true);
    }

    [Test]
    public void PlayerThrowCardOnTable()
    {
        var sut = new Player(new Card(Color.Green, 8), new Card(Color.Yellow, 5));
        var doc = new Table(new Card(Color.Yellow, 3));

        sut.ThrowCardAt(doc, new Card(Color.Yellow, 5));

        using var _ = new AssertionScope();
        doc.CardOnTop.Should().Be(new Card(Color.Yellow, 5));
        sut.Hand.Should().ContainSingle().And.Contain(new Card(Color.Green, 8));
    }
    
    //Precondicionar
    //Tirar cartas
    //Robar
    //se quita la carta de la mano
}

public class Player
{
    private readonly List<Card> hand;

    public Player(params Card[] cards)
    {
        this.hand = cards.ToList();
    }

    public IEnumerable<Card> Hand => hand;

    public bool CanThrowOn(Table table)
    {
        return hand.Any(card => card.CanBeThrownOnTopOf(table.CardOnTop));
    }

    public void ThrowCardAt(Table table, Card card)
    {
        table.Throw(card);
        hand.Remove(card);
    }
}