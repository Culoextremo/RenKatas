using UnoRen;

namespace VistaLoquesea;

public class ConsoleGameView: GameView
{
    public Task BeginTurn(int turn)
    {
        Console.WriteLine("turn: "+ turn);
        return Task.CompletedTask;
    }

    public Task ThrowCard(Card card)
    {
        Console.WriteLine("tira carta: "+ card);
        return Task.CompletedTask;
    }
    
    public Task DrawCard(Card card)
    {
        Console.WriteLine("roba carta: "+ card);
        return Task.CompletedTask;
    }

    public Task EndGame()
    {
        Console.WriteLine("winner winner chicken dinner");
        return Task.CompletedTask;
    }
}