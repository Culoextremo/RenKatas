


using FluentAssertions;

namespace UnoRen;

public class Tests
{
    [Test]
    public void METHOD()
    {
        var sut = new Card(Color.Yellow, 4);
        sut.CanBeThrownOnTopOf(new Card(Color.Yellow, 4))
            .Should().BeTrue();
    }
}

public class Card
{
    public Card(Color yellow, int i)
    {
    }

    public bool CanBeThrownOnTopOf(Card card)
    {
        return true;
    }
}

public enum Color
{
    Yellow
}