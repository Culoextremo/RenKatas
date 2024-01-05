namespace GildedRoseKata;

public class BackstagePasses : ItemDecorator
{
    public BackstagePasses(Item item) : base(item) { }

    protected override void UpdateQuality()
    {
        if(SellIn <= 0)
        {
            Quality = 0;
            return;
        }
        TryIncreaseQuality();

        if(SellIn < 11)
        {
            TryIncreaseQuality();
        }

        if(SellIn < 6)
        {
            TryIncreaseQuality();
        }
    }
}