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
    
    [Test]
    public void RemoveFlag()
    {
        var sut = new Tablero();
        sut.PlantFlag(0, 0);
        
        sut.RemoveFlag(0, 0);
        
        sut.HasFlag(0, 0).Should().Be(false);
    }

    [Test]
    public void MinesKillsYou()
    {
        var sut = new Tablero((0, 0));

        sut.RevealCell((0, 0));
        
        sut.IsGameOver.Should().BeTrue();
    }

    [Test]
    public void NotGameOverByDefault()
    {
        new Tablero((0, 0))
            .IsGameOver.Should().BeFalse();
    }

    [Test]
    public void EmptySpacesDoNotKillYou()
    {
        var sut = new Tablero((0, 0));

        sut.RevealCell((0, 1));
        
        sut.IsGameOver.Should().BeFalse();
    }

    [Test]
    public void RevealCell()
    {
        var sut = new Tablero((0, 0));
        sut.RevealCell((0,1));

        sut.IsRevealed(0, 1).Should().BeTrue();
    }
    
    [Test]
    public void CellIsNotRevealed()
    {
        var sut = new Tablero((0, 0));

        sut.IsRevealed(0, 1).Should().BeFalse();
    }
    
    [Test]
    public void IsOutOfBounds()
    {
        var sut = new Tablero(sizeX:3, sizeY: 3);

        sut.InsideBounds(3, 3).Should().Be(false);
        sut.InsideBounds(0, 0).Should().Be(true);
        sut.InsideBounds(-1, 0).Should().Be(false);
        sut.InsideBounds(0, -1).Should().Be(false);
    }

    [Test]
    public void RevealSurroundingCells()
    {
        var sut = new Tablero(sizeX: 3, sizeY: 3);
        
        sut.RevealCell((0, 0));

        sut.IsRevealed(2, 2)
            .Should().BeTrue();
    }
    
    [Test]
    public void DoNotRevealAdjacentCells_WhenSelfHasSurroundingMines()
    {
        var sut = new Tablero(sizeX: 3, sizeY: 3, (0,0));
        sut.RevealCell((0,1));
        sut.IsRevealed(2, 2).Should().BeFalse();
    }
    
    [Test]
    public void WinGame()
    {
        var sut = new Tablero(sizeX: 1, sizeY: 1);
        sut.RevealCell((0, 0));
        sut.Won.Should().BeTrue();
    }
    
    [Test]
    public void NotWonByDefault()
    {
        var sut = new Tablero(sizeX: 1, sizeY: 1);
        sut.Won.Should().BeFalse();
    }
    
    [Test]
    public void WinGameWithMines()
    {
        var sut = new Tablero(sizeX: 3, sizeY: 3, 
            (0, 0), (0, 1), (0, 2), 
            (1, 0), (1, 2), 
            (2, 0), (2, 1), (2, 2));

        sut.RevealCell((1, 1));

        sut.Won.Should().BeTrue();
    }
    
    
    // O X O
    [Test]
    public void WinGameWithSeveralReveals()
    {
        var sut = new Tablero(sizeX: 3, sizeY: 1, (1, 0));

        sut.RevealCell((0, 0));
        sut.Won.Should().BeFalse();
        
        sut.RevealCell((2, 0));
        sut.Won.Should().BeTrue();
    }
    
}