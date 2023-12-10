﻿using FluentAssertions;
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
        var game = new Game(player1, player2, new DrawPile(OtherCard), new DiscardPile(SomeCard));
        var sut = new PlayTurn(game);
        
        sut.Throw(MatchingCard);
        
        using var _ = new AssertionScope();
        game.CurrentPlayer.Should().Be(player2);
        player1.Hand.Should().NotContain(MatchingCard);
        
    }

    [Test]

    public void sdgfsdfg()
    {
        var player1 = new Player(UnmatchingCard);
        var player2 = new Player(OtherCard);
        var game = new Game(player1, player2, new DrawPile(MatchingCard), new DiscardPile(SomeCard));

        var sut = new Gameplay(game);
        sut.BeginTurn();
        
        using var _ = new AssertionScope();
        player1.Hand.Should().Contain(MatchingCard);
        game.CurrentPlayer.Should().Be(player1);
    }
}