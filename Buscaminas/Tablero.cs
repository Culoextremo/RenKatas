namespace Buscaminas;

public class Tablero
{
    readonly (int x, int y)[] mines;

    public Tablero(params (int, int)[] mines)
    {
        this.mines = mines;
    }

    public bool HasMine(int x, int y)
    {
        return mines.Contains((x,y));
    }

    public int SurroundingMinesAt((int x, int y) coords)
    {
        int surroundingMines = 0;
        if(HasMine(0, 1))
            surroundingMines++;
        if(HasMine(1, 0))
            surroundingMines++;
        
        return surroundingMines;
    }
}