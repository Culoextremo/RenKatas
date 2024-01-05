namespace GildedRoseKata;

public class Sulfuras : ItemDecorator
{
    public Sulfuras(Item item) : base(item) { }

    public override void UpdateQuality()
    {
        // SPECIAL CASE PATTERN
    }

    public override void DecreaseSellin()
    {
        // SPECIAL CASE PATTERN
    }
}