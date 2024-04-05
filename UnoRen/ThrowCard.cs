namespace UnoRen;

public class ThrowCard
{
    private readonly Game game;

    public ThrowCard(Game game)
    {
        this.game = game;
    }

    public Task Throw(Card card, GameView gameView)
    {
        Throw(card);
        return gameView?.ThrowCard(card);
    }
    public void Throw(Card card)
    {
        game.Throw(card);
        game.EndTurn();
    }
}