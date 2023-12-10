namespace UnoRen;

public class PlayTurn
{
    private readonly Game game;

    public PlayTurn(Game game)
    {
        this.game = game;
    }

    public void Throw(Card card)
    {
        game.Throw(card);
        game.EndTurn();
    }
}