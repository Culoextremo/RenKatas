using FluentAssertions;
using FluentAssertions.Execution;

namespace UnoRen;

public class Tests
{
    Card SomeCard => new Card(Color.Yellow, 4);
    Card OtherCard => new Card(Color.Yellow, 1);
    Card MatchingCard => SameColorCard;
    Card SameColorCard => new Card(Color.Yellow, 7);
    Card SameNumberAndDifferentColorCard => new Card(Color.Green, 4);
    Card UnmatchingCard => new Card(Color.Green, 8);
    [Test]
    public void CanThrowOnCardWithSameColor()
    {
        SomeCard
            .CanBeThrownOnTopOf(SameColorCard)
            .Should().BeTrue();
    }

    [Test]
    public void CanThrowOnCardWithSameNumber()
    {
        SomeCard
            .CanBeThrownOnTopOf(SameNumberAndDifferentColorCard)
            .Should().BeTrue();
    }

    [Test]
    public void CanThrowOnCardWithDifferentColorAndNumber()
    {
        SomeCard
            .CanBeThrownOnTopOf(UnmatchingCard)
            .Should().BeFalse();
    }
    
    [Test]
    public void DefaultTableCard()
    {
        var sut = new DiscardPile(SomeCard);
        sut.CardOnTop.Should().Be(SomeCard);
    }

    [Test]
    public void ThrowCardOnTop()
    {
        var sut = new DiscardPile(SomeCard);

        sut.Throw(MatchingCard);

        sut.CardOnTop.Should().Be(MatchingCard);
    }
    
    [Test]
    public void PlayerCannotThrowCardOnTable()
    {
        new Player(SomeCard)
            .CanThrowOn(new DiscardPile(UnmatchingCard))
            .Should().Be(false);
    }
    
    [Test]
    public void PlayerCanThrowCardOnTable()
    {
        var sut = new Player(SomeCard);
        var doc = new DiscardPile(MatchingCard);
        sut.CanThrowOn(doc)
            .Should().Be(true);
    }
    
    [Test]
    public void PlayerCanThrow_WithMultipleCardsInHand()
    {
        var sut = new Player(UnmatchingCard, MatchingCard);
        var doc = new DiscardPile(SomeCard);
        sut.CanThrowOn(doc)
            .Should().Be(true);
    }

    [Test]
    public void PlayerThrowCardOnTable()
    {
        var sut = new Player(UnmatchingCard, MatchingCard);
        var doc = new DiscardPile(SomeCard);

        sut.ThrowCardAt(doc, MatchingCard);

        using var _ = new AssertionScope();
        doc.CardOnTop.Should().Be(MatchingCard);
        sut.Hand.Should().ContainSingle().And.Contain(UnmatchingCard);
    }

    [Test]
    public void DrawFromDeck()
    {
        var sut = new Player(SomeCard);
        var doc = new DrawPile(OtherCard);
        
        sut.DrawFrom(doc);

        using var _ = new AssertionScope();
        sut.Hand.Contains(OtherCard).Should().BeTrue();
        doc.Should().BeEmpty();
    }

    [Test]
    public void xkdjcgdf()
    {
        var sut = new Game(new Player(MatchingCard), new Player(UnmatchingCard), new DrawPile(OtherCard), new DiscardPile(SomeCard));
        
    }
    
    //Barajar la pila de descartes si se acaba el mazo
}

public class Game
{
    public Game(Player player, Player player1, DrawPile drawPile, DiscardPile discardPile)
    {
        throw new NotImplementedException();
    }
}