namespace UnoRen;

public class Player
{
    private readonly List<Card> hand;

    public Player(params Card[] cards)
    {
        this.hand = cards.ToList();
    }

    public IEnumerable<Card> Hand => hand;

    public bool CanThrowOn(DiscardPile discardPile)
    {
        return hand.Any(card => card.CanBeThrownOnTopOf(discardPile.CardOnTop));
    }

    public void ThrowCardAt(DiscardPile discardPile, Card card)
    {
        if (!CanThrowOn(discardPile))
            throw new InvalidOperationException("Cannot throw card on table");
        if(!hand.Contains(card))
            throw new InvalidOperationException("Cannot throw card not in hand");
        
        discardPile.Throw(card);
        hand.Remove(card);
    }

    public void DrawFrom(DrawPile drawPile)
    {
        hand.Add(drawPile.Draw());
    }
}