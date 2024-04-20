namespace Buscaminas;

public class Tablero
{
    readonly (int x, int y) size;
    
    readonly (int x, int y)[] mines;
    readonly List<(int x, int y)> flags = new();
    readonly List<(int x, int y)> revealedCells = new();
    

    public Tablero(params (int, int)[] mines) : this(int.MaxValue, int.MaxValue, mines)
    {
    }

    public Tablero(int sizeX, int sizeY, params (int, int)[] mines)
    {
        size = ((sizeX, sizeY));
        this.mines = mines;
    }

    public bool IsGameOver { get; private set; } = false;

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

    public void Click(int x, int y)
    {
        revealedCells.Add((x,y));
        
        if(mines.Contains((x, y)))
        {
            IsGameOver = true;
        }
    }

    public bool IsRevealed(int x, int y)
    {
        return revealedCells.Contains((x, y));
    }

    public bool InsideBounds(int x, int y)
    {
        return size.x > x && size.y > y && x>=0 && y>=0;
    }
}