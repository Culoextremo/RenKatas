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

    public void UpdateQuality()
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].Name != "Aged Brie" && !IsBackstage(i))
            {
                if (items[i].Quality > 0)
                {
                    if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        items[i].Quality = items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (items[i].Quality < 50)
                {
                    items[i].Quality = items[i].Quality + 1;

                    if (IsBackstage(i))
                    {
                        if (items[i].SellIn < 11)
                        {
                            IncreaseQuality(i);
                        }

                        if (items[i].SellIn < 6)
                        {
                            IncreaseQuality(i);
                        }
                    }
                }
            }

            if (items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                items[i].SellIn = items[i].SellIn - 1;
            }

            if (items[i].SellIn < 0)
            {
                if (items[i].Name != "Aged Brie")
                {
                    if (!IsBackstage(i))
                    {
                        if (items[i].Quality > 0)
                        {
                            if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                items[i].Quality = items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        items[i].Quality = items[i].Quality - items[i].Quality;
                    }
                }
                else
                {
                    IncreaseQuality(i);
                }
            }
        }
    }

    void IncreaseQuality(int i)
    {
        if(items[i].Quality < 50)
        {
            items[i].Quality = items[i].Quality + 1;
        }
    }

    bool IsBackstage(int i)
    {
        return items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
    }
}