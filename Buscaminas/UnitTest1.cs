using FluentAssertions;

namespace Buscaminas;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Test1()
    {
        Tablero sut = new Tablero((0,0));
        sut.HasMine(0, 0).Should().Be(true);
    }
}

public class Tablero
{
    public Tablero((int, int) valueTuple)
    {
    }

    public bool HasMine(int i, int i1)
    {
        return true;
    }
}