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

        sut.HasMine(0, 0).Should().Be(true);
        sut.HasMine(0, 1).Should().Be(true); 
    }
     
    [Test]
    public void ghjklghj()
    {
        var sut = new Tablero((0, 1));
        sut.SurroundingMinesAt((0, 0)).Should().Be(1);
    }
    [Test]
    public void asdasdasd()
    {
        var sut = new Tablero((0, 1), (1, 0));
        sut.SurroundingMinesAt((0, 0))
            .Should().Be(2);
    }
    
    [Test]
    public void lakslkdlskl()
    {
        var sut = new Tablero((0, 1), (1, 0), (4, 3));
        sut.SurroundingMinesAt((0, 0))
            .Should().Be(2);
    }
}