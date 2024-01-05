using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<ItemDecorator> items;
    public IEnumerable<ItemDecorator> Items => items;

    public GildedRose(IList<Item> items)
    {
        this.items = items.Select(item=>
        {
            return item.Name switch
            {
                "Conjured Mana Cake" => new ConjuredItem(item),
                "Aged Brie" => new AgedBrie(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
                _ => new ItemDecorator(item)
            };
        }).ToList();
    }

    public void EndDay()
    {
        for(var i = 0; i < items.Count; i++)
        {
            UpdateItemQuality(i);
        }
    }

    void UpdateItemQuality(int i)
    {
        items[i].UpdateQuality();

        items[i].DecreaseSellin();
    }
}