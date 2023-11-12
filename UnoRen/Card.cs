namespace UnoRen;

public struct Card
{
    readonly Color color;
    readonly int number;

    public Card(Color color, int number)
    {
        this.color = color;
        this.number = number;
    }

    public bool CanBeThrownOnTopOf(Card other)
    {
        return other.color == this.color || other.number == this.number;
    }
}