using System;

namespace GildedRoseKata;

public class ConjuredItem : ItemDecorator
{
    public ConjuredItem(Item item) : base(item)
    {
        
    }
    
    protected override void TryDecreaseQuality()
    {
        if(Quality > 0)
        {
            Quality = Math.Clamp(Quality - 2, 0, int.MaxValue);
        }
    }
}