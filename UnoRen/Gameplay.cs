
namespace UnoRen;

public class Gameplay
{
    private readonly Game game;

    public Gameplay(Game game)
    {
        this.game = game;
    }

    public void BeginTurn()
    {
        if (game.CurrentPlayerCanThrow)
            return;

        game.MakePlayerDraw();

        if(!game.CurrentPlayerCanThrow)
            game.EndTurn();
    }
}