using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> items;
    public IEnumerable<Item> Items => items;

    public GildedRose(IList<Item> items)
    {
        this.items = items;
    }

    public void EndDay()
    {
        for (var i = 0; i < items.Count; i++)
        {
            UpdateItemQuality(i);
        }
    }

    void UpdateItemQuality(int i)
    {
        if(items[i].Name != "Aged Brie" && !IsBackstage(i))
        {
            TryDecreaseQuality(i);
        }
        else
        {
            jitanjáfora(i);
        }

        DecreaseSellin(i);

        if(items[i].SellIn < 0)
        {
            if(items[i].Name != "Aged Brie")
            {
                if(!IsBackstage(i))
                {
                    TryDecreaseQuality(i);
                }
                else
                {
                    items[i].Quality = 0;
                }
            }
            else
            {
                TryIncreaseQuality(i);
            }
        }
    }

    void DecreaseSellin(int i)
    {
        if(items[i].Name != "Sulfuras, Hand of Ragnaros")
        {
            items[i].SellIn = items[i].SellIn - 1;
        }
    }

    void UpdateQualityOfBackstageTicket(int i)
    {
        if(items[i].SellIn < 11)
        {
            TryIncreaseQuality(i);
        }

        if(items[i].SellIn < 6)
        {
            TryIncreaseQuality(i);
        }
    }

    void TryDecreaseQuality(int i)
    {
        if(items[i].Quality > 0)
        {
            if(items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                items[i].Quality--;
            }
        }
    }

    void TryIncreaseQuality(int i)
    {
        if(items[i].Quality < 50)
        {
            items[i].Quality++;
        }
        
        
    }

    void jitanjáfora(int i)
    {
        if(IsBackstage(i))
        {
            UpdateQualityOfBackstageTicket(i);
        }
        TryIncreaseQuality(i);
    }

    bool IsBackstage(int i)
    {
        return items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
    }
}