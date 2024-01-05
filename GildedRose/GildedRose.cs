using System.Collections.Generic;
using System.Linq;
using static GildedRoseKata.ItemDecorator;

namespace GildedRoseKata;

public class GildedRose
{
    public IEnumerable<ItemDecorator> Items { get; }

    public GildedRose(IEnumerable<Item> items)
    {
        this.Items = items.Select(Decorate);
    }

    public void EndDay()
    {
        foreach(var item in Items)
        {
            item.UpdateQuality();
            item.DecreaseSellin();
        }
    }
}