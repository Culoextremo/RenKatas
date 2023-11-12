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
        var sut = new DiscardPile(new Card(Color.Yellow, 3));
        sut.CardOnTop.Should().Be(new Card(Color.Yellow, 3));
    }

    [Test]
    public void ThrowCardOnTop()
    {
        var sut = new DiscardPile(new Card(Color.Yellow, 3));

        sut.Throw(new Card(Color.Yellow, 7));

        sut.CardOnTop.Should().Be(new Card(Color.Yellow, 7));
    }
    
    [Test]
    public void PlayerCannotThrowCardOnTable()
    {
        var sut = new Player(new Card(Color.Green, 3));
        var doc = new DiscardPile(new Card(Color.Yellow, 7));
        sut.CanThrowOn(doc)
            .Should().Be(false);
    }
    
    [Test]
    public void PlayerCanThrowCardOnTable()
    {
        var sut = new Player(new Card(Color.Green, 3));
        var doc = new DiscardPile(new Card(Color.Yellow, 3));
        sut.CanThrowOn(doc)
            .Should().Be(true);
    }
    
    [Test]
    public void PlayerCanThrow_WithMultipleCardsInHand()
    {
        var sut = new Player(new Card(Color.Green, 8), new Card(Color.Yellow, 3));
        var doc = new DiscardPile(new Card(Color.Yellow, 3));
        sut.CanThrowOn(doc)
            .Should().Be(true);
    }

    [Test]
    public void PlayerThrowCardOnTable()
    {
        var sut = new Player(new Card(Color.Green, 8), new Card(Color.Yellow, 5));
        var doc = new DiscardPile(new Card(Color.Yellow, 3));

        sut.ThrowCardAt(doc, new Card(Color.Yellow, 5));

        using var _ = new AssertionScope();
        doc.CardOnTop.Should().Be(new Card(Color.Yellow, 5));
        sut.Hand.Should().ContainSingle().And.Contain(new Card(Color.Green, 8));
    }

    [Test]
    public void DrawFromDeck()
    {
        var sut = new Player(new Card(Color.Yellow, 3));
        var doc = new DrawPile(new Card(Color.Green, 8));
        
        sut.DrawFrom(doc);

        using var _ = new AssertionScope();
        sut.Hand.Contains(new Card(Color.Green, 8)).Should().BeTrue();
        doc.Should().BeEmpty();
    }
    //Barajar la pila de descartes si se acaba el mazo
}

public class Player
{
    private readonly List<Card> hand;

    public Player(params Card[] cards)
    {
        this.hand = cards.ToList();
    }

    public IEnumerable<Card> Hand => hand;

    public bool CanThrowOn(DiscardPile discardPile)
    {
        return hand.Any(card => card.CanBeThrownOnTopOf(discardPile.CardOnTop));
    }

    public void ThrowCardAt(DiscardPile discardPile, Card card)
    {
        if (!CanThrowOn(discardPile))
            throw new InvalidOperationException("Cannot throw card on table");
        if(!hand.Contains(card))
            throw new InvalidOperationException("Cannot throw card not in hand");
        
        discardPile.Throw(card);
        hand.Remove(card);
    }

    public void DrawFrom(DrawPile drawPile)
    {
        hand.Add(drawPile.Draw());
    }
}