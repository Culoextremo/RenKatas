namespace GildedRoseKata;

public class AgedBrie : ItemDecorator
{
    public AgedBrie(Item item) : base(item)
    {
        
    }
    
    public override void UpdateQuality()
    {
        if (SellIn <= 0)
        {
            TryIncreaseQuality();
        }

        TryIncreaseQuality();
    }
}

public class ConjuredItem : ItemDecorator
{
    public ConjuredItem(Item item) : base(item)
    {
        
    }
    
    protected override void TryDecreaseQuality()
    {
        if(Quality > 0)
        {
            if(Name != "Sulfuras, Hand of Ragnaros")
            {
                Quality-= 2;
            }
        }
    }
}