using System;

namespace GildedRoseKata;

public class ItemDecorator
{
    readonly Item item;
    public string Name => item.Name;
    public int SellIn
    {
        get => item.SellIn;
        set => item.SellIn = value;
    }

    public int Quality
    {
        get => item.Quality;
        set => item.Quality = value;
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
    
    void TryDecreaseQuality()
    {
        if(Quality > 0)
        {
            if(Name != "Sulfuras, Hand of Ragnaros")
            {
                Quality--;
            }
        }
    }

    public void DecreaseSellin()
    {
        if(Name == "Sulfuras, Hand of Ragnaros")
            return;

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