namespace UnoRen;

public class Game
{
    readonly Player player1;
    readonly Player player2;
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
        this.players = players;
        turn = 0;
        this.discardPile = discardPile;
    }

    public Player WhoseIsTheTurn => players[turn % players.Length];

    public bool CurrentPlayerCanThrow => WhoseIsTheTurn.CanThrowOn(discardPile);

    public void EndTurn()
    {
        turn++;
    }
}