using FluentAssertions;

namespace Buscaminas;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void HasMineAtPosition()
    {
        Tablero sut = new Tablero((0,0));
        sut.HasMine(0, 0)
            .Should().Be(true);
    }

    [Test]
    public void DoesNotHaveMineAtPosition()
    {
        var sut = new Tablero((0, 0));

        sut.HasMine(0, 1)
            .Should().BeFalse();
    }

    [Test]
    public void HasSeveralMines()
    {
        var sut = new Tablero((0, 0), (0, 1));

        sut.HasMine(0, 0).Should().Be(true);
        sut.HasMine(0, 1).Should().Be(true); 
    }
     
    [Test]
    public void OneSurroundingMine()
    {
        var sut = new Tablero((0, 1));
        sut.SurroundingMinesAt((0, 0)).Should().Be(1);
    }
    [Test]
    public void TwoSurroundingMines()
    {
        var sut = new Tablero((0, 1), (1, 0));
        sut.SurroundingMinesAt((0, 0))
            .Should().Be(2);
    }
    
    [Test]
    public void TwoSurroundingMines_andOneNotSurrounding()
    {
        var sut = new Tablero((0, 1), (1, 0), (4, 3));
        sut.SurroundingMinesAt((0, 0))
            .Should().Be(2);
    }
    
    [Test]
    public void SurroundingMineNotAtOrigin()
    {
        var sut = new Tablero((0, 2));
        sut.SurroundingMinesAt((0, 1))
            .Should().Be(1);
    }

    [Test]
    public void EightSurroundingMines()
    {
        var sut = new Tablero(
            (0, 0), (0, 1), (0, 2), 
            (1, 0), (1, 2), 
            (2, 0), (2, 1), (2, 2));

        sut.SurroundingMinesAt((1, 1))
            .Should().Be(8);
    }
    
    [Test]
    public void SelfIsNotSurrounding()
    {
        var sut = new Tablero((0, 0));

        sut.SurroundingMinesAt((0, 0))
            .Should().Be(0);
    }

    [Test]
    public void Flag()
    {
        var sut = new Tablero();

        sut.PlantFlag(0, 0);
        sut.HasFlag(0, 0)
            .Should().BeTrue();
        sut.HasFlag(0, 1)
            .Should().BeFalse();
    }
    
    //Poner bandera
    //Click y perder
    //Ganar cuando solo quedan las minas
    //Quitar bandera
    //Lo que no hay nada, revela lo que no hay nada al rededor.
    //El tablero tiene un tamaño
}