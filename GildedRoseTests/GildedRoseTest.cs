using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void akdjkajkds()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        sut.Items.Single().SellIn.Should().Be(9);
        sut.Items.Single().Quality.Should().Be(9);
    }
}