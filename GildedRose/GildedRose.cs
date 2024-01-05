using System.Collections.Generic;
using System.Linq;
using static GildedRoseKata.ItemDecorator;

namespace GildedRoseKata;

public class GildedRose
{
    readonly bool winter;
    private bool evenDay = false;
    bool ShouldUpdateQuality => !winter || evenDay;
    public IEnumerable<ItemDecorator> Items { get; }

    public GildedRose(IEnumerable<Item> items, bool winter = false)
    {
        this.winter = winter;
        Items = items.Select(Decorate);
    }

    public void EndDay()
    {
        foreach(var item in Items)
            item.Tick(ShouldUpdateQuality);

        evenDay = !evenDay;
    }
}