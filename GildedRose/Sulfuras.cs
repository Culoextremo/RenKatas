namespace GildedRoseKata;

public class Sulfuras : ItemDecorator
{
    public Sulfuras(Item item) : base(item) { }

    protected override void UpdateQuality()
    {
        // SPECIAL CASE PATTERN
    }

    protected override void DecreaseSellin()
    {
        // SPECIAL CASE PATTERN
    }
}