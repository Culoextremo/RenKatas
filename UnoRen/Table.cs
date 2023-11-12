namespace UnoRen;

public class Table
{
    public Table(Card card)
    {
        CardOnTop = card;
    }

    public Card CardOnTop { get; private set; }

    public void Throw(Card card)
    {
        CardOnTop = card;
    }
}