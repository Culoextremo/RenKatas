namespace Buscaminas;

public class Tablero
{
    readonly (int x, int y) size;
    
    readonly (int x, int y)[] mines;
    readonly List<(int x, int y)> flags = new();
    readonly List<(int x, int y)> revealedCells = new();
    

    public Tablero(params (int, int)[] mines) : this(5, 5, mines)
    {
    }

    public Tablero(int sizeX, int sizeY, params (int, int)[] mines)
    {
        size = ((sizeX, sizeY));
        this.mines = mines;
    }

    public bool IsGameOver { get; private set; } = false;
    public bool Won => !IsGameOver && revealedCells.Count == size.x * size.y - mines.Length;

    public bool HasMine(int x, int y)
    {
        if(!InsideBounds(x, y))
            throw new ArgumentException();
            
        return mines.Contains((x,y));
    }

    public int SurroundingMinesAt((int x, int y) position)
    {
        if(!InsideBounds(position.x, position.y))
            throw new ArgumentException();
        
        int surroundingMines = 0;

        for(int x = position.x - 1; x <= position.x + 1; x++)
        {
            for(int y = position.y - 1; y <= position.y + 1; y++)
            {
                if(!InsideBounds(x,y) || position == (x,y) || !HasMine(x, y))
                    continue;
                
                surroundingMines++;
            }
        }

        return surroundingMines;
    }

    public void PlantFlag(int x, int y)
    {
        if(!InsideBounds(x, y))
            throw new ArgumentException();
        
        if(HasFlag(x, y))
            throw new InvalidOperationException("FLAGGED ALREADY");
        
        flags.Add((x, y));
    }

    public bool HasFlag(int x, int y)
    {
        if(!InsideBounds(x, y))
            throw new ArgumentException();
        
        return flags.Contains((x, y));
    }

    public void RemoveFlag(int x, int y)
    {
        if(!InsideBounds(x, y))
            throw new ArgumentException();
        
        if(!HasFlag(x, y))
            throw new InvalidOperationException("NO FLAG");
        
        flags.Remove((x, y));
    }

    public void RevealCell((int x, int y) position)
    {
        if(!InsideBounds(position.x, position.y))
            throw new ArgumentException();
            
        revealedCells.Add((position.x,position.y));
        
        if(mines.Contains((position.x, position.y)))
        {
            IsGameOver = true;
        }
        
        if (SurroundingMinesAt(position)> 0) return;
        
        for(int x = position.x - 1; x <= position.x + 1; x++)
        {
            for(int y = position.y - 1; y <= position.y + 1; y++)
            {
                if(position == (x,y) || !InsideBounds(x,y) || IsRevealed(x,y))
                    continue;
                
                RevealCell((x,y));
            }
        }
    }

    public bool IsRevealed(int x, int y)
    {
        if(!InsideBounds(x, y))
            throw new ArgumentException();
        
        return revealedCells.Contains((x, y));
    }

    public bool InsideBounds(int x, int y)
    {
        return size.x > x && size.y > y && x>=0 && y>=0;
    }
}