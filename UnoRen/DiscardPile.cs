namespace UnoRen;

public class DiscardPile
{
    readonly DrawPile drawPile;

    public DiscardPile(Card card)
    {
        CardOnTop = card;
    }

    public DiscardPile(DrawPile drawPile, Card card) : this(card)
    {
        this.drawPile = drawPile;
    }

    public Card CardOnTop { get; private set; }

    public void Throw(Card card)
    {
        if (!card.CanBeThrownOnTopOf(CardOnTop))
            throw new ArgumentException("Invalid Card!");
        
        CardOnTop = card;
    }
}