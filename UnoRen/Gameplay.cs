
namespace UnoRen;

public class Gameplay
{
    private readonly Game game;
    private readonly ThrowCard throwCard;
    private readonly ThrowCardInput input;
    private readonly GameView view;

    public Gameplay(Game game, ThrowCard throwCard, ThrowCardInput input)
    {
        this.game = game;
        this.throwCard = throwCard;
        this.input = input;
    }
    
    public Gameplay(Game game, ThrowCard throwCard, ThrowCardInput input, GameView view)
    {
        this.game = game;
        this.throwCard = throwCard;
        this.input = input;
        this.view = view;
    }

    public async Task Play()
    {
        while (game.Playing)
        {
            view?.BeginTurn(game.Turn);

            if (game.CurrentPlayerCanThrow)
            {
                await throwCard.Throw(await input.ChooseCard(), view);
                continue;
            }

            game.MakePlayerDraw();

            if(!game.CurrentPlayerCanThrow)
                game.EndTurn();
        }
        view.EndGame();
    }
}