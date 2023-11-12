


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

    [Test]
    public void aksdjksjkad()
    {
        var sut = new Card(Color.Yellow, 4);
        sut.CanBeThrownOnTopOf(new Card(Color.Green, 4))
            .Should().BeTrue();
    }

    [Test]
    public void asdasdasd()
    {
        var sut = new Card(Color.Yellow, 8);
        sut.CanBeThrownOnTopOf(new Card(Color.Green, 4))
            .Should().BeFalse();
    }
    
    //Otro numero mismo color
}

public class Card
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

public enum Color
{
    Yellow,
    Green
}