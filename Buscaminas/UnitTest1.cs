using FluentAssertions;

namespace Buscaminas;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void skdjskjdk()
    {
        Tablero sut = new Tablero((0,0));
        sut.HasMine(0, 0)
            .Should().Be(true);
    }

    [Test]
    public void METHOD()
    {
        var sut = new Tablero((0, 0));

        sut.HasMine(0, 1)
            .Should().BeFalse();
    }
}

public class Tablero
{
    readonly (int, int) mine;

    public Tablero((int, int) mine)
    {
        this.mine = mine;
    }

    public bool HasMine(int x, int y)
    {
        return mine == (x, y);
    }
}