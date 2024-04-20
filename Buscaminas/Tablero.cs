namespace Buscaminas;

public class Tablero
{
    readonly (int x, int y)[] mines;
    readonly List<(int x, int y)> flags = new();

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

    public void PlantFlag(int x, int y)
    {
        if(HasFlag(x, y))
            throw new InvalidOperationException("FLAGGED ALREADY");
        
        flags.Add((x, y));
    }

    public bool HasFlag(int x, int y)
    {
        return flags.Contains((x, y));
    }

    public void RemoveFlag(int x, int y)
    {
        if(!HasFlag(x, y))
            throw new InvalidOperationException("NO FLAG");
        
        flags.Remove((x, y));
    }
}