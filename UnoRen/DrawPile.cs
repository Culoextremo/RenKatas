using System.Collections;

namespace UnoRen;

public class DrawPile : IEnumerable<Card>
{
    readonly Stack<Card> content;

    public DrawPile(params Card[] content)
    {
        this.content = new Stack<Card>(content);
    }

    public Card Draw() => content.Pop();

    public IEnumerator<Card> GetEnumerator()
    {
        return content.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}