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
    public void QualityDecreasesDouble_AfterSellingDate()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 20 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().SellIn.Should().Be(-1);
        sut.Items.Single().Quality.Should().Be(18);
    }
    
    [Test]
    public void QualityDecreasesNormaly_OnSellInDate()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 20 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().SellIn.Should().Be(0);
        sut.Items.Single().Quality.Should().Be(19);
    }

    [Test]
    public void QualityIsNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().SellIn.Should().Be(0);
        sut.Items.Single().Quality.Should().Be(0);
    }

    [Test]
    public void AgeCheese()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 7 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().SellIn.Should().Be(4);
        sut.Items.Single().Quality.Should().Be(8);
    }
    
    [Test]
    public void AgeCheeseALot()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 7 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().SellIn.Should().Be(-1);
        sut.Items.Single().Quality.Should().Be(9);
    }
    
    [Test]
    public void afgdsdfg()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();
        
        sut.Items.Single().Quality.Should().Be(50);
    }
}