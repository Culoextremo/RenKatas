using System;

namespace GildedRoseKata;

public class ItemDecorator
{
    readonly Item item;
    public string Name => item.Name;

    public static ItemDecorator Decorate(Item item)
    {
        return item.Name switch
        {
            "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
            "Conjured Mana Cake" => new ConjuredItem(item),
            "Aged Brie" => new AgedBrie(item),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
            _ => new ItemDecorator(item)
        };
    }
    public int SellIn
    {
        get => item.SellIn;
        private set => item.SellIn = value;
    }

    public int Quality
    {
        get => item.Quality;
        protected set => item.Quality = value;
    }

    public ItemDecorator(Item item)
    {
        this.item = item;
    }

    public virtual void UpdateQuality()
    {
        TryDecreaseQuality();
        if(SellIn <= 0)
        {
            TryDecreaseQuality();
        }
    }
    
    protected virtual void TryDecreaseQuality()
    {
        if(Quality > 0)
        {
            Quality--;
        }
    }

    public virtual void DecreaseSellin()
    {
        SellIn--;
    }
    protected void TryIncreaseQuality()
    {
        if(Quality < 50)
        {
            Quality++;
        }
    }
}