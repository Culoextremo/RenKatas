using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void PassADay()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        sut.Items.Single().SellIn.Should().Be(9);
        sut.Items.Single().Quality.Should().Be(9);
    }
    
    [Test]
    public void PsdfgsdfgdsgDay()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 20 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().SellIn.Should().Be(-1);
        sut.Items.Single().Quality.Should().Be(18);
    }
    
    [Test]
    public void PsdfgsddfagsdfgfgdsgDay()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 20 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().SellIn.Should().Be(0);
        sut.Items.Single().Quality.Should().Be(19);
    }
}