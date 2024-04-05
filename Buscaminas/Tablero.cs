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

    public int SurroundingMinesAt((int x, int y) position)
    {
        int surroundingMines = 0;

        for(int x = position.x - 1; x <= position.x + 1; x++)
        {
            for(int y = position.y - 1; y <= position.y + 1; y++)
            {
                if(position == (x,y) || !HasMine(x, y))
                    continue;
                
                surroundingMines++;
            }
        }

        return surroundingMines;
    }
}