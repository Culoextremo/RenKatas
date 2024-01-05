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
                "Aged Brie" => new AgedBrie(item),
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
        switch(items[i].Name)
        {
            case "Backstage passes to a TAFKAL80ETC concert":
                BackStageQuality(i);
                break;
            default:
                items[i].UpdateQuality();
                break;
        }

        DecreaseSellin(i);
    }
    
    void DecreaseSellin(int i)
    {
        if(items[i].Name == "Sulfuras, Hand of Ragnaros")
            return;

        items[i].SellIn--;
    }
    
    void TryIncreaseQuality(int i)
    {
        if(items[i].Quality < 50)
        {
            items[i].Quality++;
        }
    }

    void BackStageQuality(int i)
    {
        if(items[i].SellIn <= 0)
        {
            items[i].Quality = 0;
            return;
        }
        TryIncreaseQuality(i);

        if(items[i].SellIn < 11)
        {
            TryIncreaseQuality(i);
        }

        if(items[i].SellIn < 6)
        {
            TryIncreaseQuality(i);
        }
    }
}