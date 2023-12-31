﻿namespace UnoRen;

public class Game
{
    readonly Player player1;
    readonly Player player2;
    private readonly DrawPile drawPile;
    private readonly Player[] players;
    private int turn;
    private readonly DiscardPile discardPile;


    public Game(Player player1, Player player2, DrawPile drawPile, DiscardPile discardPile) : this(drawPile,
        discardPile, player1, player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        turn = 0;
    }

    public Game(DrawPile drawPile, DiscardPile discardPile, params Player[] players)
    {
        this.drawPile = drawPile;
        this.players = players;
        turn = 0;
        this.discardPile = discardPile;
    }

    public Player CurrentPlayer => players[turn % players.Length];

    public bool CurrentPlayerCanThrow => CurrentPlayer.CanThrowOn(discardPile);
    public bool GameOver => !Playing;
    public bool Playing => players.All(x => x.Hand.Any());
    public int Turn => turn;

    public void EndTurn()
    {
        turn++;
    }

    public void Throw(Card card)
    {
        CurrentPlayer.ThrowCardAt(discardPile, card);
    }

    public void MakePlayerDraw()
    {
        CurrentPlayer.DrawFrom(drawPile);
    }
}