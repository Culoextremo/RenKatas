
namespace UnoRen;

public class Gameplay
{
    private readonly Game game;
    private readonly ThrowCard throwCard;
    private readonly ThrowCardInput input;

    public Gameplay(Game game, ThrowCard throwCard, ThrowCardInput input)
    {
        this.game = game;
        this.throwCard = throwCard;
        this.input = input;
    }

    public async Task BeginTurn()
    {
        if (game.CurrentPlayerCanThrow)
        {
            throwCard.Throw(await input.ChooseCard());
            return;
        }

        game.MakePlayerDraw();

        if(!game.CurrentPlayerCanThrow)
            game.EndTurn();
    }
}