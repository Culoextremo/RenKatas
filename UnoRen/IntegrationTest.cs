using FluentAssertions;
using FluentAssertions.Execution;
using static UnoRen.TestApi;

namespace UnoRen;

public class IntegrationTest
{
    [Test]
    public void EndTurnAfterThrowingCard()
    {
        var player1 = new Player(MatchingCard, OtherCard);
        var player2 = new Player(OtherCard);
        var discardPile = new DiscardPile(SomeCard);
        var game = new Game(player1, player2, new DrawPile(OtherCard), discardPile);
        var sut = new ThrowCard(game);
        
        sut.Throw(MatchingCard);
        
        using var _ = new AssertionScope();
        game.CurrentPlayer.Should().Be(player2);
        player1.Hand.Should().NotContain(MatchingCard);
        discardPile.CardOnTop.Should().Be(MatchingCard);
    }


    [Test]
    public void DrawCardWhenPlayerCannotThrow()
    {
        var player1 = new Player(UnmatchingCard);
        var player2 = new Player(OtherCard);
        var game = new Game(player1, player2, new DrawPile(MatchingCard), new DiscardPile(SomeCard));

        var sut = new Gameplay(game, new ThrowCard(game), new FakeInput(5f, MatchingCard));
        sut.Play();
        
        using var _ = new AssertionScope();
        player1.Hand.Should().Contain(MatchingCard);
        game.CurrentPlayer.Should().Be(player1);
    }
    [Test]
    public void EndTurn_WhenPlayerCannotThrow_AfterDrawing()
    {
        var player1 = new Player(UnmatchingCard);
        var player2 = new Player(OtherCard);
        var game = new Game(player1, player2, new DrawPile(UnmatchingCard), new DiscardPile(SomeCard));

        var sut = new Gameplay(game, new ThrowCard(game), new FakeInput(5f, MatchingCard));
        sut.Play();
        
        using var _ = new AssertionScope();
        game.CurrentPlayer.Should().Be(player2);
    }

    [Test]

    public async Task adfjghdsfjg()
    {
        var player1 = new Player(MatchingCard);
        var player2 = new Player(OtherCard);
        var game = new Game(player1, player2, new DrawPile(UnmatchingCard), new DiscardPile(SomeCard));

        var doc = new ThrowCard(game);
        var sut = new Gameplay(game, doc,  new FakeInput(0.5f, MatchingCard));
        sut.Play();
        await Task.Delay(600);
        game.CurrentPlayer.Should().Be(player2);
    }
    
    [Test]
    public async Task fghdghfd()
    {
        var player1 = new Player(MatchingCard, OtherCard);
        var player2 = new Player(UnmatchingCard);
        var game = new Game(player1, player2, new DrawPile(UnmatchingCard), new DiscardPile(SomeCard));

        var doc = new ThrowCard(game);
        var sut = new Gameplay(game, doc,  new FakeInput(0.5f, MatchingCard));
        sut.Play();
        await Task.Delay(600);
        player2.Hand.Count().Should().Be(2);
        
    }
}

public class FakeInput : ThrowCardInput
{
    private float time;
    private Card card;
    public FakeInput(float time, Card card)
    {
        this.time = time;
        this.card = card;
    }

    public async Task<Card> ChooseCard()
    {
        await Task.Delay((int)(time * 1000));
        return card;
    }
}

public interface ThrowCardInput
{
    Task<Card> ChooseCard();
}