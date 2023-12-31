using FluentAssertions;
using FluentAssertions.Execution;
using static UnoRen.TestApi;

namespace UnoRen;

public class UnitTests
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
    public void Player1Begins()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(UnmatchingCard);
        var sut = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));

        sut.CurrentPlayer
            .Should().Be(player1);
    }

    [Test]
    public void EndTurn()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(UnmatchingCard);
        var sut = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));

        sut.EndTurn();

        sut.CurrentPlayer.Should().Be(player2);
    }

    [Test]
    public void MoreThanTwoPlayersEndTurn()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(UnmatchingCard);
        var player3 = new Player(UnmatchingCard);
        var sut = new Game(new DrawPile(OtherCard), new DiscardPile(SomeCard), player1, player2, player3);

        sut.EndTurn();
        sut.EndTurn();

        sut.CurrentPlayer.Should().Be(player3);
    }
    
    [Test]
    public void LastPlayerTurnIsFollowedByFirst()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(UnmatchingCard);
        var sut = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));

        sut.EndTurn();
        sut.EndTurn();

        sut.CurrentPlayer.Should().Be(player1);
    }

    [Test]
    public void CurrentPlayerCanThrow()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(OtherCard);
        var sut = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));

        sut.CurrentPlayerCanThrow.Should().Be(true);
    }
    
    [Test]
    public void CurrentPlayerCannotThrow()
    {
        var player1 = new Player(UnmatchingCard);
        var player2 = new Player(OtherCard);
        var sut = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));

        sut.CurrentPlayerCanThrow.Should().Be(false);
    }

    [Test]
    public void METHOD()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(OtherCard);
        var sut = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));
        
        sut.Throw(MatchingCard);
        
        sut.GameOver.Should().BeTrue();
    }
    [Test]
    public void asdasd()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(OtherCard);
        var sut = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));
        
        sut.Playing
            .Should().BeTrue();
    }
    //Barajar la pila de descartes si se acaba el mazo
}