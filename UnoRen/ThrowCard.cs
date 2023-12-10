namespace UnoRen;

public class ThrowCard
{
    private readonly Game game;

    public ThrowCard(Game game)
    {
        this.game = game;
    }

    public void Throw(Card card)
    {
        game.Throw(card);
        game.EndTurn();
    }
}