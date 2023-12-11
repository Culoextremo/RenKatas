using UnoRen;

namespace VistaLoquesea;

public class ConsoleGameView: GameView
{
    public Task BeginTurn(int turn)
    {
        Console.WriteLine("turn: "+ turn);
        return Task.CompletedTask;
    }
}