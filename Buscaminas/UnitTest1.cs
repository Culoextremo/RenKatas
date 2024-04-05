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

    [Test]
    public void ksjdksjkd()
    {
        var sut = new Tablero((0, 0), (0, 1));
    }
}

public class Tablero
{
    readonly (int, int)[] mines;

    public Tablero(params (int, int)[] mines)
    {
        this.mines = mines;
    }

    public bool HasMine(int x, int y)
    {
        return mines.Contains((x,y));
    }
}