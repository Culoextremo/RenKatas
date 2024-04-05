namespace UnoRen;

public interface GameView
{
    Task BeginTurn(int turn);
    Task ThrowCard(Card card);
    Task DrawCard(Card card);
    Task EndGame();
}