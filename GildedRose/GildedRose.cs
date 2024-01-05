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
        for(var i = 0; i < items.Count; i++)
        {
            UpdateItemQuality(i);
        }
    }

    void UpdateItemQuality(int i)
    {
        if(items[i].Name == "Aged Brie")
        {
            ComportamientoQueso(i);
        }
        else if(IsBackstage(i))
        {
            BackStageQuality(i);
        }
        else
        {
            TryDecreaseQuality(i);
        }

        DecreaseSellin(i);

        if(items[i].SellIn >= 0)
            return;

        //ESTO OCURRE CUANDO ESTA PASAO DE FECHA
        if(items[i].Name == "Aged Brie")
        {
            TryIncreaseQuality(i);
        }
        else
        {
            if(IsBackstage(i))
            {
                items[i].Quality = 0;
            }
            else
            {
                TryDecreaseQuality(i);
            }
        }
    }

    void ComportamientoQueso(int i)
    {
        TryIncreaseQuality(i);
    }

    void DecreaseSellin(int i)
    {
        if(items[i].Name == "Sulfuras, Hand of Ragnaros")
            return;

        items[i].SellIn--;
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

    void BackStageQuality(int i)
    {
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

    bool IsBackstage(int i)
    {
        return items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
    }
}