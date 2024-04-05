namespace Buscaminas;

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

    public int SurroundingMinesAt((int, int) coords)
    {
        return mines.Length;
    }
}