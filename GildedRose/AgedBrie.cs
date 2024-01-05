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