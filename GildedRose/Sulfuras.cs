﻿namespace GildedRoseKata;

public class Sulfuras : ItemDecorator
{
    public Sulfuras(Item item) : base(item) { }

    public override void Tick(bool shouldUpdateQuality)
    {
        //SPECIAL CASE PATTERN
    }
}