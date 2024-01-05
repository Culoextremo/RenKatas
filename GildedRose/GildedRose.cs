using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    public IEnumerable<ItemDecorator> Items { get; }

    public GildedRose(IEnumerable<Item> items)
    {
        this.Items = items.Select(item=>
        {
            return item.Name switch
            {
                "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
                "Conjured Mana Cake" => new ConjuredItem(item),
                "Aged Brie" => new AgedBrie(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
                _ => new ItemDecorator(item)
            };
        }).ToList();
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